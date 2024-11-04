namespace PuntoDeVenta.Models
{
    public class Proveedores
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public List<Productos> Productos { get; set; }

    }
}
