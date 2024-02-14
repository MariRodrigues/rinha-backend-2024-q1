using BancoAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace BancoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Transacoes)
                .WithOne(t => t.Cliente)
                .HasForeignKey(t => t.ClienteId);
        }
    }
}
