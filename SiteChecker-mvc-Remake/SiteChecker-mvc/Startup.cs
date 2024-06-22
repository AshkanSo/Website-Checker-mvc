namespace SiteChecker_mvc;

public class StartUp : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<StartUp> _logger;

    public StartUp(IServiceProvider serviceProvider, ILogger<StartUp> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var ServiceA = scope.ServiceProvider.GetRequiredService<ServiceA>();
                await ServiceA.ExecuteTask(stoppingToken);
            }
                
            await Task.Delay(15000, stoppingToken);
        }
    }
}