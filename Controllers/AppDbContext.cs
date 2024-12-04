using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

public class AppDbContext : DbContext
{
    public DbSet<GhibliGirls> GhibliGirls { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
}