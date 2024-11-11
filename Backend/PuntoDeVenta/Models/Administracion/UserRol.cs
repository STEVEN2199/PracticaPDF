namespace PuntoDeVenta.Models.Administracion
{
    public class UserRol
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int RolId { get; set; }

        public Roles Rol { get; set; }

        // Lugar Donde se conecta.
        // public int EmpresaId { get; set; }

    }
}