using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Models;
using PuntoDeVenta.Models.Administracion;

namespace PuntoDeVenta.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Productos> Productos { get; set; }

        public DbSet<Bodega> Bodegas { get; set; }

        public DbSet<CLiente> Clientes { get; set; }

        public DbSet<Proveedores> Proveedores { get; set; }

        public DbSet<Sede> Proveedores { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
