using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteChecker_mvc.Models;

namespace SiteChecker_mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly SiteCheckerDbContext _context;
    
    public HomeController(ILogger<HomeController> logger,SiteCheckerDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public Task<List<WebSites>> Websites { get;set; }
    public IActionResult Index()
    {
        
        var websites = _context.WebSites.ToList();
        return View(websites);
    }

       //
       // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
       // public IActionResult Error()
       // {
       //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
       // }


    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(WebSites obj)
    {
        
            _context.WebSites.Add(obj);
            _context.SaveChanges();
            TempData["Success"] = "Website Created Successfully";
            return RedirectToAction("Index");
        
    }
   
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        WebSites? categoryfromdb = _context.WebSites.Find(id);
        if (categoryfromdb == null)
        {
            return NotFound();
        }
        return View(categoryfromdb);
    }
    [HttpPost , ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
       
        WebSites? obj = _context.WebSites.Find(id);
        if (obj == null)
        { 
            return NotFound();
        }
        _context.WebSites.Remove(obj);
        _context.SaveChanges();
        TempData["Success"] = "Category Deleted Successfully";
        return RedirectToAction("Index");
           
    }
    
    //**************************************************
    public IActionResult Edit(int? id)
    {
        if (id==null || id==0)
        {
            return NotFound();
        }

        WebSites? categoryfromdb = _context.WebSites.Find(id);
        if (categoryfromdb==null)
        {
            return NotFound();
        }
        return View(categoryfromdb);
    }
    [HttpPost]
    public IActionResult Edit(WebSites obj)
    {
       
        if (ModelState.IsValid)
        {
                
            _context.WebSites.Update(obj);
            _context.SaveChanges();
            TempData["Success"] = "WebSite Updated Successfully";
            return RedirectToAction("Index");
        }

        else
        {
            return View();
        }

    }
    //***********************************************
    public IActionResult Detail(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var errorLogss = _context.ErrorLogs.Where(x => x.FK_WebSiteId == id);
        
        
        return View(errorLogss);
    }

    public IActionResult AllErrors()
    {
        var errorLogs = _context.ErrorLogs.ToList();
        return View(errorLogs);
    }
    
}