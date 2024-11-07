using JiBen.Server.Data.Models;
using JiBen.Server.Data.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace JiBen.Server.Data;

/// <summary>
///     The database context for the JiBen system.
/// </summary>
public class JiBenDbContext : DbContext
{
    public DbSet<JiBenSystem> JiBenSystems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Release> ProductReleases { get; set; }

    /// <summary>
    ///     Empty constructor.
    /// </summary>
    public JiBenDbContext()
    {
    }

    /// <summary>
    ///     Constructor with DbContextOptions.
    /// </summary>
    /// <param name="options">The DbContextOptions to pass to the DbContext.</param>
    public JiBenDbContext(DbContextOptions<JiBenDbContext> options) : base(options)
    {
    }
    
    /// <inheritdoc />
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Setup Sqlite database for now.
        optionsBuilder.UseSqlite("Data Source=jiben.db");
    }
}