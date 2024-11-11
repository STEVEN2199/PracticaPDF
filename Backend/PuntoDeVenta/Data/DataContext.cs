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

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Proveedores> Proveedores { get; set; }

        public DbSet<Sede> Sede { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Permisos> Permisos { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<UserRol> UsersRol { get; set; }

        public DbSet<UserRolPermisos> UsersRolPermisos { get; set; }

    }
}
