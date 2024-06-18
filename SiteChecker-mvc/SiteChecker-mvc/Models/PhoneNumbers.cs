namespace SiteChecker_mvc.Models;

public class PhoneNumbers
{
    
    public int PK_PhoneNumber { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }

    public ICollection<WebSites> WebSitesCollection { get; set; } = null;
    
    
}