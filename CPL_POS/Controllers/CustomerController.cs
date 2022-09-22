using CPL_POS.Data;
using CPL_POS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CPL_POS.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Customer());
            }
            else
            {
                var EditCust = await _context.Customers.FirstOrDefaultAsync(e => e.CustomerId == id);
                if (EditCust == null)
                {
                    return NotFound();
                }


                return View(EditCust);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    customer.CreatedOn = DateTime.Now;
                    _context.Customers.Add(customer);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Customers.Update(customer);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CustomerExists(customer.CustomerId))
                        {
                            return NotFound();

                        }
                        else
                        {
                            throw;
                        }

                    }
                }

                return Json(new { isvalid = true, html = Helper.RederRazorViewToString(this, "_ViewAll", _context.Customers.ToList()) });
            }
            return Json(new { isvalid = false, html = Helper.RederRazorViewToString(this, "AddOrEdit", customer) });


        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerModel = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customerModel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RederRazorViewToString(this, "_ViewAll", _context.Customers.ToList()) });

        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
