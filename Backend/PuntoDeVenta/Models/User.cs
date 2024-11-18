using System.ComponentModel.DataAnnotations;

namespace PuntoDeVenta.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        public string PasswordHash { get; set; } = string.Empty;

        public int TokenVersion { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<UserRole> UserRoles { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; } = new();
    }
}
