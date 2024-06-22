namespace SiteChecker_mvc.Models;
using Microsoft.EntityFrameworkCore;

public class SiteCheckerDbContext : DbContext
{
    public SiteCheckerDbContext(DbContextOptions<SiteCheckerDbContext> options) : base(options)
    {
        
    }

    public DbSet<WebSites> WebSites { get; set; }
    // public DbSet<PhoneNumbers> PhoneNumbers { get; set; }
    public DbSet<ErrorLogs> ErrorLogs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WebSites>().HasKey(e => e.PK_WebSite);
        modelBuilder.Entity<ErrorLogs>().HasKey(e => e.PK_ErrorLogs);

        modelBuilder.Entity<WebSites>()
            .Property(w => w.PK_WebSite)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<ErrorLogs>()
            .Property(w => w.PK_ErrorLogs)
            .ValueGeneratedOnAdd();

    
        
        modelBuilder.Entity<WebSites>().HasData(
            new WebSites
                { PK_WebSite = 1,Name = "Fadia", Url = "https://fadiashop.com/wakeup", ServerStatus = 
                    true, Number1 = "091322222", Number2 = ""});
        
        modelBuilder.Entity<WebSites>().HasData(
            new WebSites
            {
                 PK_WebSite = 2,Name = "Varzesh3", Url = "https://www.varzesh3.com/livescore", ServerStatus = true,
               Number1 = "0913111111" , Number2 = "0912555555"
            });
    }
    
}