using System.ComponentModel.DataAnnotations;

namespace PuntoDeVenta.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
