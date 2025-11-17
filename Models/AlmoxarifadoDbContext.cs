using Microsoft.EntityFrameworkCore;

namespace SistemaAlmoxarifado.Models
{
   
    ///Banco de Dados - Entity Framework Core
   
    public class AlmoxarifadoDbContext : DbContext
    {
        public DbSet<Material> Materiais { get; set; }
        public DbSet<EntradaMaterial> EntradasMateriais { get; set; }
        public DbSet<SaidaMaterial> SaidasMateriais { get; set; }
        public DbSet<AjusteEstoque> AjustesEstoque { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                
                //SQL Server Express
                optionsBuilder.UseSqlServer(
                    @"Server=localhost\SQLEXPRESS;Database=SistemaAlmoxarifado;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;",
                    options => options.EnableRetryOnFailure()
                );
                
               
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração de indice unico para o codigo do material
            modelBuilder.Entity<Material>()
                .HasIndex(m => m.Codigo)
                .IsUnique();

            // Configuração de relacionanentos
            modelBuilder.Entity<EntradaMaterial>()
                .HasOne(e => e.Material)
                .WithMany(m => m.Entradas)
                .HasForeignKey(e => e.MaterialId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SaidaMaterial>()
                .HasOne(s => s.Material)
                .WithMany(m => m.Saidas)
                .HasForeignKey(s => s.MaterialId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AjusteEstoque>()
                .HasOne(a => a.Material)
                .WithMany(m => m.Ajustes)
                .HasForeignKey(a => a.MaterialId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
