namespace SiteChecker_mvc.Models;

public class ErrorLogs
{
   

    public int PK_ErrorLogs { get; set; }
    public string ErrorCode { get; set; }
    public DateTime StartOfError { get; set; }
    public DateTime EndOfError { get; set; }

    public int FK_WebSiteId { get; set; }
    public WebSites WebSite { get; set; }
 
}