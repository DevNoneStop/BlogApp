using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.DB;

public class Context : DbContext
{

    public DbSet<AppUser> Users { get; set; }
    public DbContext()
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}