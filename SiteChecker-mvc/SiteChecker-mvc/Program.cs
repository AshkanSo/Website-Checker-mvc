using SiteChecker_mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SiteChecker_mvc.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SiteCheckerDbContext>(options =>
    options.UseSqlite("Data Source=SiteChecker.db"));
builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddWindowsService();
builder.Services.AddRazorPages();

builder.Services.AddHttpClient<ServiceA>(); 
builder.Services.AddScoped<ServiceA>();
builder.Services.AddHostedService<StartUp>();

// builder.Services.AddWindowsService();
// builder.Services.AddHostedService<ServiceA>();
var app = builder.Build();
app.MapRazorPages();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
// host.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();