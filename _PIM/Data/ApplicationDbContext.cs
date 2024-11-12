using Microsoft.EntityFrameworkCore;
using _PIM.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace _PIM.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ProdutoModel> Produto { get; set; }
        public DbSet<PlantaModel> Plantas { get; set; }
        public DbSet<SensorModel> Sensores { get; set; }
    }
}
