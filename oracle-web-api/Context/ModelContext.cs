using Microsoft.EntityFrameworkCore;
using oracle_web_api.Models;

namespace oracle_web_api.Context
{
    public partial class ModelContext : DbContext
    {
        public virtual DbSet<Attention> Attentions { get; set; }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Esto es en caso de que necesites especificar el nombre de la tabla y el esquema.
            /* modelBuilder.Entity<Attention>(entity =>
            {
                entity.HasKey(e => e.AttentionId); // Asumiendo que AttentionId es la clave primaria.
                entity.ToTable("Attention", "hmetro"); // Especifica el nombre de la tabla y el esquema si es necesario.
            }); */

            // Aquí puedes configurar más modelos según sea necesario
        }
    }
}
