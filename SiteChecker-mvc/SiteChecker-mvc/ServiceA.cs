using System.Net;
using Microsoft.EntityFrameworkCore;
using SiteChecker_mvc.Models;

namespace SiteChecker_mvc;

public class ServiceA
{
    private readonly ILogger<ServiceA> _logger;
    private readonly SiteCheckerDbContext _context;
    private List<WebSites> _siteCheckers;
    private readonly HttpClient _httpClient;

    private Dictionary<int, bool> serverStatus = new();
    private Dictionary<int, DateTime?> errorStartTimes = new();
    private Dictionary<int, DateTime?> errorEndTimes = new();

    public ServiceA(ILoggerFactory loggerFactory, HttpClient httpClient,SiteCheckerDbContext context)
    {
        Logger = loggerFactory.CreateLogger<ServiceA>();
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _context = context;
    }

    public ILogger Logger { get; }

   
    public async Task<List<WebSites>> GetWebSitesAsync()
    {
        return await _context.WebSites.ToListAsync();
    }

    public async Task<List<WebSites>> GetWebSitesWithPhoneNumbersAsync()
    {
        return await _context.WebSites
            .Include(ws => ws.PhoneNumbers)
            .ToListAsync();
    }

    public async Task ExecuteTask(CancellationToken stoppingToken)
    {
        try
        {
            var websites = await GetWebSitesAsync();
            foreach (var website in websites)
            {
                try
                {

                    var response = await _httpClient.GetAsync(website.Url, stoppingToken);
                if (response.IsSuccessStatusCode)
                {
                    if (website.ServerStatus == false)
                    {
                        var phones = await GetWebSitesWithPhoneNumbersAsync();
                        foreach (var phone in phones)
                        {
                            //Send SMS WebSite Is Up
                        }
                        
                        errorEndTimes[website.PK_WebSite] = DateTime.Now;
                        var errorLog = new ErrorLogs
                        {
                            ErrorCode = "503",
                            StartOfError = errorStartTimes[website.PK_WebSite].Value,
                            EndOfError = errorEndTimes[website.PK_WebSite].Value,
                            FK_WebSiteId = website.PK_WebSite
                        };
                        _context.ErrorLogs.Add(errorLog);
                        await _context.SaveChangesAsync(stoppingToken);
                        errorStartTimes[website.PK_WebSite] = null;
                        Console.WriteLine($"{website.Name}: OK");
                    }
                    Console.WriteLine($"{website.Name}: OK");
                    serverStatus[website.PK_WebSite] = true;
                }
                else if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                {
                    if (website.ServerStatus == true)
                    {
                        errorStartTimes[website.PK_WebSite] = DateTime.Now;
                        var phones = await GetWebSitesWithPhoneNumbersAsync();
                        foreach (var phone in phones)
                        {
                            //Send SMS WebSite Is Down
                        }
                        
                        serverStatus[website.PK_WebSite] = false; 
                    }
                    Console.WriteLine($"{website.Name}: Error");
                    serverStatus[website.PK_WebSite] = false; 
                }
                else
                {
                    Console.WriteLine($"{website.Name}: Can't Check This Site");
                }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{website.Name}: Can't Check This Site");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($" Can't Check This Site");
        }
    }
}
