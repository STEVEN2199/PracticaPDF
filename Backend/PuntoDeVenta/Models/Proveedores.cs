using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PuntoDeVenta.Models
{
    public class Proveedores
    {
        [Key]
        public int IdProveedor { get; set; }

        [MaxLength(255)]
        public string Nombre { get; set; }

        [MaxLength(255)]
        public string Direccion { get; set; }

        [MaxLength(255)]
        public string Telefono { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }
        public List<Productos> Productos { get; set; }

    }
}
