using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace PuntoDeVenta.Middleware
{
    public class PermissionMiddleware
    {
        private readonly RequestDelegate _next;

        public PermissionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            var roleClaims = context.User.FindAll(ClaimTypes.Role).Select(c => c.Value);
            if (!roleClaims.Contains("Admin")) // Ejemplo de permiso
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Forbidden");
                return;
            }

            await _next(context);
        }
    }
}
