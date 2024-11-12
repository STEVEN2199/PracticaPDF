using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PuntoDeVenta.Models
{
    public class Sede
    {
        [Key]
        public int IdSede { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
