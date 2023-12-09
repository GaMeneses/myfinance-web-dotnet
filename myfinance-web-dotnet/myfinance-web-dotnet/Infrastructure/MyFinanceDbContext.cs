using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Enumerations;

namespace myfinance_web_dotnet.Infrastructure
{
    public class MyFinanceDbContext : DbContext
    {
        public MyFinanceDbContext()
        {
        }

        public MyFinanceDbContext(DbContextOptions<MyFinanceDbContext> options)
            : base(options)
        {


        }

        public DbSet<PlanoContaModel> PlanoConta { get; set; }
        public DbSet<TransacaoModel> Transacao { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectionString = "Data Source=DESKTOP-NGI9LGA\\SQLEXPRESS;Initial Catalog=myfinanceweb;Integrated Security=True; TrustServerCertificate=True";
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlanoContaModel>(entity => 
            {

                entity.HasKey(p => p.Id);

                entity.Property(p => p.Descricao)
                    .IsRequired();

                entity.Property(m => m.Tipo)
                    .HasConversion(new EnumToNumberConverter<TipoConta, int>())
                    .IsRequired();

            });


            modelBuilder.Entity<TransacaoModel>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Historico);

                entity.Property(p => p.Tipo);

                entity.Property(p => p.Valor)
                    .HasConversion<decimal>();

                entity.HasOne(p => p.PlanoConta)
                    .WithMany(p => p.Transacoes)
                    .HasForeignKey(d => d.PlanoContaId);

            });
                
                

        }
    }
}
