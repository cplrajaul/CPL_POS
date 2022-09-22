using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPL_POS.Data;
using CPL_POS.Models;

namespace CPL_POS.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }





        [HttpGet]
        public async Task<ActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Category());
            }
            else
            {
                var EditCat = await _context.Categories.FirstOrDefaultAsync(e => e.CategoryId == id);
                if (EditCat == null)
                {
                    return NotFound();
                }


                return View(EditCat);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    category.CreatedOn = DateTime.Now;
                    _context.Categories.Add(category);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Categories.Update(category);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CategoryExists(category.CategoryId))
                        {
                            return NotFound();

                        }
                        else
                        {
                            throw;
                        }

                    }
                }

                return Json(new { isvalid = true, html = Helper.RederRazorViewToString(this, "_ViewAll", _context.Categories.ToList()) });
            }
            return Json(new { isvalid = false, html = Helper.RederRazorViewToString(this, "AddOrEdit", category) });


        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryModel = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(categoryModel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RederRazorViewToString(this, "_ViewAll", _context.Categories.ToList()) });

        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}
