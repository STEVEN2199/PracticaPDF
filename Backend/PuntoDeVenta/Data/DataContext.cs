using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Models;

namespace PuntoDeVenta.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public DbSet<Productos> Productos { get; set; }
        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Sede> Sedes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>(entity =>
            {
                entity.Property(e => e.Nombre).HasMaxLength(255);
                entity.Property(e => e.Descripcion).HasMaxLength(1000);
            });

            modelBuilder.Entity<Bodega>(entity =>
            {
                entity.Property(e => e.Nombre).HasMaxLength(255);
                entity.Property(e => e.Direccion).HasMaxLength(500);
                entity.Property(e => e.Telefono).HasMaxLength(20);
            });

            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.Property(e => e.Nombre).HasMaxLength(255);
                entity.Property(e => e.Direccion).HasMaxLength(500);
                entity.Property(e => e.Telefono).HasMaxLength(20);
            });

            modelBuilder.Entity<Sede>(entity =>
            {
                entity.Property(e => e.Nombre).HasMaxLength(255);
                entity.Property(e => e.Direccion).HasMaxLength(500);
                entity.Property(e => e.Telefono).HasMaxLength(20);
            });
        }
    }

}
