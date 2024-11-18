namespace PuntoDeVenta.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public bool IsRevoked { get; set; } = false;
        public string CreatedByIp { get; set; } = string.Empty;
        public string? ReplacedByToken { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
