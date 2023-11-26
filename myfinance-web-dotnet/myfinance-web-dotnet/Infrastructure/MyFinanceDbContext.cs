using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain;

namespace myfinance_web_dotnet.Infrastructure
{
    public class MyFinanceDbContext : DbContext
    {
        public DbSet<PlanoContaModel> PlanoConta { get; set; }
        public DbSet<TransacaoModel> Transacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=Gabriel;Initial Catalog=myfinanceweb;Integrated Security=True; TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlanoContaModel>()
                .Property(p => p.Tipo)
                .HasConversion<int>();  
        }
    }
}
