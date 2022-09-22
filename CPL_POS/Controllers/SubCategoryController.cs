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
    public class SubCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubCategories.ToListAsync());
        }


        [HttpGet]
        public async Task<ActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new SubCategory());
            }
            else
            {
                var EditSubCat = await _context.SubCategories.FirstOrDefaultAsync(e => e.SubCategoryId == id);
                if (EditSubCat == null)
                {
                    return NotFound();
                }


                return View(EditSubCat);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    subCategory.CreatedOn = DateTime.Now;
                    _context.SubCategories.Add(subCategory);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.SubCategories.Update(subCategory);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SubCategoryExists(subCategory.SubCategoryId))
                        {
                            return NotFound();

                        }
                        else
                        {
                            throw;
                        }

                    }
                }

                return Json(new { isvalid = true, html = Helper.RederRazorViewToString(this, "_ViewAll", _context.SubCategories.ToList()) });
            }
            return Json(new { isvalid = false, html = Helper.RederRazorViewToString(this, "AddOrEdit", subCategory) });


        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCategoryModel = await _context.SubCategories.FindAsync(id);
            _context.SubCategories.Remove(subCategoryModel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RederRazorViewToString(this, "_ViewAll", _context.SubCategories.ToList()) });

        }
        private bool SubCategoryExists(int id)
        {
            return _context.SubCategories.Any(e => e.SubCategoryId == id);
        }
    }
}
