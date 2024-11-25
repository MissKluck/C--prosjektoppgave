using Microsoft.EntityFrameworkCore;

public class GhibliGirlsDb : DbContext
{
    public DbSet<Characters> Characters { get; set; }

    public GhibliGirlsDb(DbContextOptions<GhibliGirlsDb> options) : base(options)
    {

    }
}