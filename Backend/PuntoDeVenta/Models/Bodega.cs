namespace PuntoDeVenta.Models
{
    public class Bodega
    {
        public int IdBodega { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public List<Productos> Productos { get; set; }
    }
}
