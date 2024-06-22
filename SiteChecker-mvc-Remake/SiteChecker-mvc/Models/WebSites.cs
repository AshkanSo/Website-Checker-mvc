
namespace SiteChecker_mvc.Models;

public class WebSites
{
    public int PK_WebSite { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public bool ServerStatus { get; set; } = true;
    public string Number1 { get; set; } = null;
    public string Number2 { get; set; } = null;
    
    public ICollection<ErrorLogs> ErrorLogsCollection { get; set; } = null;
}