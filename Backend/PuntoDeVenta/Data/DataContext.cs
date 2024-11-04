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

    }
}
