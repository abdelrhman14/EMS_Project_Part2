using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Event_Management_system.Data;
using Event_Management_system.Models;

namespace Event_Management_system.Controllers
{
    public class InvestorsController : Controller
    {
        private readonly AppDbContext _context;

        public InvestorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Investors
        public async Task<IActionResult> Index()
        {
              return _context.Investors != null ? 
                          View(await _context.Investors.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Investors'  is null.");
        }
      
        // GET: Investors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Investors == null)
            {
                return NotFound();
            }

            var investor = await _context.Investors
                .FirstOrDefaultAsync(m => m.Investor_Id == id);
            if (investor == null)
            {
                return NotFound();
            }

            return View(investor);
        }

        // GET: Investors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Investors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Investor_Id,Name,Mobile")] Investor investor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(investor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(investor);
        }

        // GET: Investors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Investors == null)
            {
                return NotFound();
            }

            var investor = await _context.Investors.FindAsync(id);
            if (investor == null)
            {
                return NotFound();
            }
            return View(investor);
        }

        // POST: Investors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Investor_Id,Name,Mobile")] Investor investor)
        {
            if (id != investor.Investor_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestorExists(investor.Investor_Id))
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
            return View(investor);
        }

        // GET: Investors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Investors == null)
            {
                return NotFound();
            }

            var investor = await _context.Investors
                .FirstOrDefaultAsync(m => m.Investor_Id == id);
            if (investor == null)
            {
                return NotFound();
            }

            return View(investor);
        }

        // POST: Investors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Investors == null)
            {
                return Problem("Entity set 'AppDbContext.Investors'  is null.");
            }
            var investor = await _context.Investors.FindAsync(id);
            if (investor != null)
            {
                _context.Investors.Remove(investor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
      
        private bool InvestorExists(int id)
        {
          return (_context.Investors?.Any(e => e.Investor_Id == id)).GetValueOrDefault();
        }
    }
}
