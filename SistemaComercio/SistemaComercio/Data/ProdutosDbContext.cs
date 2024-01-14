using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using SistemaComercio.Model;
namespace SistemaComercio.Data;

public class ProdutosDbContext : DbContext
{
    public ProdutosDbContext(DbContextOptions<ProdutosDbContext> options) : base(options)
    {
    }
  
    public DbSet<ProdutosModel> Product { get; set; }
}
