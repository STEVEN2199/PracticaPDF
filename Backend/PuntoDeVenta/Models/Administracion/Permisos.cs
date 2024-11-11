namespace PuntoDeVenta.Models.Administracion
{
    public class Permisos
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // nombre del modulo
        public string Resource { get; set; }

        // accion descripta: Ex. ver-usuarios-administracion.
        public string Action { get; set; }

        public int Active { get; set; } = 1;

    }
}