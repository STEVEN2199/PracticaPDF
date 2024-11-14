using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Models

{
    public class Bodega
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBodega { get; set; }

        [MaxLength(255)]
        public string Nombre { get; set; }

        [MaxLength(255)]
        public string Direccion { get; set; }

        [MaxLength(255)]
        public string Telefono { get; set; }
        public List<Productos> Productos { get; set; }
    }
}
