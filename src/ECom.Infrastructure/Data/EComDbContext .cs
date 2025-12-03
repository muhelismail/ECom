using ECom.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECom.Infrastructure.Data;

public class EComDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ProductEntity> Products { get; set; }
}
