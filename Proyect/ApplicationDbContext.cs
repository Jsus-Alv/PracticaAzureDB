using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // DbSet property for your 'CentralitaTelefonica' table
    public DbSet<CentralitaTelefonica> CentralitaTelefonicas { get; set; }
}
