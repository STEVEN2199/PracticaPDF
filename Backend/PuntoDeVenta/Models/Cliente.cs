namespace PuntoDeVenta.Models
{
    public class Cliente
    {

        public int Id { get; set; }

        public string Names { get; set; }

        public string DNI { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;

        public DateTime UpdateAt { get; set; }
    }
}