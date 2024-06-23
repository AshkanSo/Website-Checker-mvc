using Microsoft.AspNetCore.Mvc;
using SiteChecker_mvc.Models;

namespace SiteChecker_mvc.Controllers;

public class LoginController : Controller
{
    private readonly SiteCheckerDbContext _context;

    // GET
    public LoginController(SiteCheckerDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    // [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _context.Users
            .FirstOrDefault(u => u.Username == username && u.Password == password);
    
        if (user != null)
        {
            // کاربر پیدا شد، ورود موفقیت‌آمیز
            // می‌توانید اطلاعات کاربر را در سشن ذخیره کنید
            HttpContext.Session.SetString("Username", user.Username);
            return RedirectToAction("Index", "Home");
        }
        else
        {
            // کاربر پیدا نشد، ورود ناموفق
            ViewBag.Error = "Invalid username or password";
            return View();
        }
    }

    public IActionResult Register()
    {
        return View();
    }
}