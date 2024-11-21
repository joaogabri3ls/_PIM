using Microsoft.EntityFrameworkCore;
using _PIM.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace _PIM.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ProdutoModel> Produto { get; set; }


        public override int SaveChanges()
        {
            AtualizarStatusProdutos();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AtualizarStatusProdutos();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AtualizarStatusProdutos()
        {
            foreach (var entry in ChangeTracker.Entries<ProdutoModel>())
            {
                if (entry.State == EntityState.Modified || entry.State == EntityState.Added)
                {
                    if (entry.Entity.Quantidade <= 0)
                    {
                        entry.Entity.Ativo = false;
                    }
                    else
                    {
                        entry.Entity.Ativo = true;
                    }
                }
            }
        }
    }
}