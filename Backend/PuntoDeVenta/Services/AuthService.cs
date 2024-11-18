using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Data;
using PuntoDeVenta.Dtos;
using PuntoDeVenta.Models;

namespace PuntoDeVenta.Services
{
    public class AuthService
    {
        private readonly DataContext _context;
        private readonly TokenService _tokenService;

        public AuthService(DataContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email)) return false;

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<(string AccessToken, string RefreshToken)> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return (null, null);

            var roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();
            var accessToken = _tokenService.GenerateAccessToken(user, roles);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshTokens.Add(new RefreshToken
            {
                Token = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                CreatedByIp = "127.0.0.1"
            });

            await _context.SaveChangesAsync();
            return (accessToken, refreshToken);
        }

        public async Task<string> RefreshTokenAsync(RefreshTokenDto dto)
        {
            var refreshToken = await _context.RefreshTokens
                .Include(rt => rt.User)
                .FirstOrDefaultAsync(rt => rt.Token == dto.RefreshToken && !rt.IsRevoked);

            if (refreshToken == null || refreshToken.ExpiryDate <= DateTime.UtcNow) return null;

            refreshToken.IsRevoked = true;
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            refreshToken.User.RefreshTokens.Add(new RefreshToken
            {
                Token = newRefreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                CreatedByIp = "127.0.0.1"
            });

            await _context.SaveChangesAsync();

            var roles = refreshToken.User.UserRoles.Select(ur => ur.Role.Name).ToList();
            return _tokenService.GenerateAccessToken(refreshToken.User, roles);
        }
    }
}
