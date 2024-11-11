namespace PuntoDeVenta.Models.Administracion
{
    public class Roles
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } = null;

        public int Active { get; set; } = 1;
    }
}