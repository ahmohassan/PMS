using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMS.Data;
using PMS.Models;

namespace PMS.Controllers
{
    public class purchasingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public purchasingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: purchasings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.purchasing.Include(p => p.Customer).Include(p => p.Medicine);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: purchasings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchasing = await _context.purchasing
                .Include(p => p.Customer)
                .Include(p => p.Medicine)
                .FirstOrDefaultAsync(m => m.purchasingID == id);
            if (purchasing == null)
            {
                return NotFound();
            }

            return View(purchasing);
        }

        // GET: purchasings/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.customers, "CustomerID", "CustomerFullname");
            ViewData["MedicineID"] = new SelectList(_context.medicines, "MedicineID", "MedicineName");
            return View();
        }

        // POST: purchasings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("purchasingID,Price,Date,CustomerID,MedicineID")] purchasing purchasing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchasing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.customers, "CustomerID", "CustomerID", purchasing.CustomerID);
            ViewData["MedicineID"] = new SelectList(_context.medicines, "MedicineID", "MedicineID", purchasing.MedicineID);
            return View(purchasing);
        }

        // GET: purchasings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchasing = await _context.purchasing.FindAsync(id);
            if (purchasing == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.customers, "CustomerID", "CustomerID", purchasing.CustomerID);
            ViewData["MedicineID"] = new SelectList(_context.medicines, "MedicineID", "MedicineID", purchasing.MedicineID);
            return View(purchasing);
        }

        // POST: purchasings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("purchasingID,Price,Date,CustomerID,MedicineID")] purchasing purchasing)
        {
            if (id != purchasing.purchasingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchasing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!purchasingExists(purchasing.purchasingID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.customers, "CustomerID", "CustomerID", purchasing.CustomerID);
            ViewData["MedicineID"] = new SelectList(_context.medicines, "MedicineID", "MedicineID", purchasing.MedicineID);
            return View(purchasing);
        }

        // GET: purchasings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchasing = await _context.purchasing
                .Include(p => p.Customer)
                .Include(p => p.Medicine)
                .FirstOrDefaultAsync(m => m.purchasingID == id);
            if (purchasing == null)
            {
                return NotFound();
            }

            return View(purchasing);
        }

        // POST: purchasings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchasing = await _context.purchasing.FindAsync(id);
            _context.purchasing.Remove(purchasing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool purchasingExists(int id)
        {
            return _context.purchasing.Any(e => e.purchasingID == id);
        }
    }
}
