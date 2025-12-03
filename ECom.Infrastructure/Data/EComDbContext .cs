using Microsoft.EntityFrameworkCore;

namespace ECom.Infrastructure.Data;

public class EComDbContext(DbContextOptions options) : DbContext(options)
{

}
