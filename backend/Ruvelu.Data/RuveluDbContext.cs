using Microsoft.EntityFrameworkCore;
using Ruvelu.Core.Entities;

namespace Ruvelu.Data
{
public class RuveluDbContext : DbContext
{
    public RuveluDbContext(DbContextOptions<RuveluDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;
    
}
}