using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SiteChecker_mvc.Models;

namespace SiteChecker_mvc.Controllers;

public class PhoneNumbersController : Controller
{
    private readonly SiteCheckerDbContext _context;
    
    public PhoneNumbersController(SiteCheckerDbContext context)
    {
        _context = context;
    }
    
    public IActionResult PhoneNumbers()
    {
        var phoneNumbers = _context.PhoneNumbers.ToList();
        return View(phoneNumbers);
    }
   
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(PhoneNumbers obj)
    {
            _context.PhoneNumbers.Add(obj);
            _context.SaveChanges();
            TempData["Success"] = "Contact Created Successfully";
            return RedirectToAction("PhoneNumbers");
    }
    
    //***************************************
    
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        PhoneNumbers? phone = _context.PhoneNumbers.Find(id);
        if (phone == null)
        {
            return NotFound();
        }
        return View(phone);
    }
    [HttpPost , ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
       
        PhoneNumbers? phone = _context.PhoneNumbers.Find(id);
        if (phone == null)
        { 
            return NotFound();
        }
        _context.PhoneNumbers.Remove(phone);
        _context.SaveChanges();
        TempData["Success"] = "Contact Deleted Successfully";
        return RedirectToAction("PhoneNumbers");
           
    }
    //*******************************************
    
    public IActionResult Edit(int? id)
    {
        if (id==null || id==0)
        {
            return NotFound();
        }

        PhoneNumbers? phone = _context.PhoneNumbers.Find(id);
        if (phone==null)
        {
            return NotFound();
        }
        return View(phone);
    }
    [HttpPost]
    public IActionResult Edit(PhoneNumbers phone)
    {
       
        if (ModelState.IsValid)
        {
                
            _context.PhoneNumbers.Update(phone);
            _context.SaveChanges();
            TempData["Success"] = "WebSite Updated Successfully";
            return RedirectToAction("Index");
        }

        else
        {
            return View();
        }

    }
    
}