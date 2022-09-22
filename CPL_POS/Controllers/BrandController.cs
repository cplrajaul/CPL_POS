using CPL_POS.Data;
using CPL_POS.Models;
using CPL_POS.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CPL_POS.Controllers
{
    public class BrandController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BrandController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Brands.ToListAsync());
        }

        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new BrandViewModel());
            }
            else
            {
                var brand = await _context.Brands.FirstOrDefaultAsync(e => e.BrandId == id);
                var BrandViewModel = new BrandViewModel()
                {
                    Id = brand.BrandId,
                    BrandName = brand.BrandName,
                    CreatedOn = brand.CreatedOn,
                    ExistingImage = brand.BrandLogo,
                    ModifiedBy = brand.ModifiedBy,
                   


                };

                if (brand == null)
                {
                    return NotFound();
                }
                return View(BrandViewModel);
            }

        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, BrandViewModel model)
        {


            if (ModelState.IsValid)
            {


                if (id == 0)
                {
                    string uniqueFileName = ProcessUploadedFile(model);
                    Brand brand = new()
                    {
                        BrandName = model.BrandName,
                        CreatedOn = model.CreatedOn,
                        BrandLogo = uniqueFileName,
                        ModifiedBy = model.ModifiedBy,
                     
                    };
                    _context.Add(brand);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        var brand = await _context.Brands.FindAsync(model.Id);
                        brand.BrandName = model.BrandName;
                        brand.CreatedOn = model.CreatedOn;
                        brand.ModifiedBy = model.ModifiedBy;
                       

                        if (model.BrandPicture != null)
                        {
                            if (model.ExistingImage != null)
                            {
                                string filePath = Path.Combine(_env.WebRootPath, "Uploads", model.ExistingImage);
                                System.IO.File.Delete(filePath);
                            }

                            brand.BrandLogo = ProcessUploadedFile(model);
                        }
                        _context.Update(brand);
                        await _context.SaveChangesAsync();


                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!BrandExists(model.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }


                return Json(new { isvalid = true, html = Helper.RederRazorViewToString(this, "_ViewAll", _context.Brands.ToList()) });
            }
            return Json(new { isvalid = false, html = Helper.RederRazorViewToString(this, "AddOrEdit", model) });
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RederRazorViewToString(this, "_ViewAll", _context.Brands.ToList()) });
        }


        private string ProcessUploadedFile(BrandViewModel model)
        {
            string uniqueFileName = null;

            if (model.BrandPicture != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "Uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.BrandPicture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                model.BrandPicture.CopyTo(fileStream);
            }

            return uniqueFileName;
        }

        private bool BrandExists(int id)
        {
            return _context.Brands.Any(e => e.BrandId == id);
        }

    }
}
