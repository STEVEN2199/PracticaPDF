namespace PuntoDeVenta.Models.Administracion
{
    public class UserRolPermisos
    {
        public int Id { get; set; }

        public int UserRolId { get; set; }

        public UserRol UserRol { get; set; }

        public int PermisoId { get; set; }

        public Permisos Permiso { get; set; }

        // Notificar al User en la app web cuando se le otorga el permiso.
        public int notify { get; set; } = 0;

        public int active { get; set; } = 1;

        public ICollection<Permisos> Permisos { get; set; }
    }
}