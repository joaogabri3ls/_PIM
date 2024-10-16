using Microsoft.EntityFrameworkCore;
using _PIM.Models;

namespace _PIM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ProdutoModel> Produtos { get; set; }
    }
}
