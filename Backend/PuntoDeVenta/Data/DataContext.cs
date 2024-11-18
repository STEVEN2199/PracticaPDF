using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Models;
using Microsoft.AspNetCore.Identity;

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
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRole {  get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }



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
                entity.Property(e => e.IdBodega).ValueGeneratedOnAdd();
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

            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<RefreshToken>()
                .HasIndex(rt => rt.Token)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }

}
