using Microsoft.EntityFrameworkCore;
using Prova.Data.Map;
using Prova.Modelos;

namespace Prova.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options): base(options)
        {
        }
        public DbSet<UsuarioModelo> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
