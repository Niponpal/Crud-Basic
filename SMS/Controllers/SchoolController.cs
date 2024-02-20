using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.DataBase;
using SMS.Models;

namespace SMS.Controllers;

public class SchoolController : Controller
{
	private readonly SchoolDb schoolDb;
    public SchoolController(SchoolDb schoolDb)
    {
        this.schoolDb = schoolDb;
        
    }
    [HttpGet]
    public async Task<IActionResult> Index()
	{
        var data=await schoolDb.Set<School>().AsNoTracking().ToListAsync();
		return View(data);
	}
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(int id)
    {
        if (id==0)
        {
            return View(new School());
            
        }
        else
        {
            var data = await schoolDb.Set<School>().FindAsync(id);
            return View(data);
        }

    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(int id, School schoo)
    {
        if (id==0)
        {
            if (ModelState.IsValid)
            {
                await schoolDb.Set<School>().AddAsync(schoo);
                await schoolDb.SaveChangesAsync();
                return RedirectToAction("Index");
                
            }
        }
        else
        {
           schoolDb.Set<School>().Update(schoo);
            schoolDb.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(schoo);

    }
    public async Task<IActionResult>Delted(int id)
    {
        if (id!=0)
        {
            var data = await schoolDb.Set<School>().FindAsync(id);
            if (data is not null)
            {
                 schoolDb.Set<School>().Remove(data);
                await schoolDb.SaveChangesAsync();
                                                
            }
        }
        return RedirectToAction("Index");
    }
    public async Task<IActionResult>Details(int id)
    {
        var data = await schoolDb.Set<School>().FindAsync(id);
        return View(data);
    }
}
