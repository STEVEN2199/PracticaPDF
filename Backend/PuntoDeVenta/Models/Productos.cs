using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PuntoDeVenta.Models
{
    public class Productos
    {
        [Key]
        public int IdProduct { get; set; }

        [MaxLength(255)]
        public string Nombre { get; set; }

        [MaxLength(255)]
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }

        public List<Proveedores> Proveedores { get; set; }
    }
}
