namespace SiteChecker_mvc.Models;
using Microsoft.EntityFrameworkCore;

public class SiteCheckerDbContext : DbContext
{
    public SiteCheckerDbContext(DbContextOptions<SiteCheckerDbContext> options) : base(options)
    {
        
    }

    public DbSet<WebSites> WebSites { get; set; }
    public DbSet<PhoneNumbers> PhoneNumbers { get; set; }
    public DbSet<ErrorLogs> ErrorLogs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WebSites>().HasKey(e => e.PK_WebSite);
        modelBuilder.Entity<PhoneNumbers>().HasKey(e => e.PK_PhoneNumber);
        modelBuilder.Entity<ErrorLogs>().HasKey(e => e.PK_ErrorLogs);
        
        
        modelBuilder.Entity<PhoneNumbers>().HasData(
            new PhoneNumbers {PK_PhoneNumber = 1, Name = "User1", Number = "123456" });
        modelBuilder.Entity<PhoneNumbers>().HasData(
            new PhoneNumbers {PK_PhoneNumber = 2,Name = "Contact1", Number = "987654" });

        
        modelBuilder.Entity<WebSites>().HasData(
            new WebSites
                { PK_WebSite = 1,Name = "Fadia", Url = "https://fadiashop.com/wakeup", ServerStatus = 
                    true, PhoneNumbers = new List<PhoneNumbers>(1) });
        
        modelBuilder.Entity<WebSites>().HasData(
            new WebSites
            {
                 PK_WebSite = 2,Name = "Varzesh3", Url = "https://www.varzesh3.com/livescore", ServerStatus = true,
                PhoneNumbers = new List<PhoneNumbers>(2)
            });
    }
    
}