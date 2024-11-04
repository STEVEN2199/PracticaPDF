namespace PuntoDeVenta.Models
{
    public class Productos
    {
        public int IdProduct { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }

        public List<Proveedores> Proveedores { get; set; }
    }
}
