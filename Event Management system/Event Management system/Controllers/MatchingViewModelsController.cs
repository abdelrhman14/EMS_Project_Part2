using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Event_Management_system.Data;
using Event_Management_system.Models;
using System.Collections;

namespace Event_Management_system.Controllers
{
    public class MatchingViewModelsController : Controller
    {
        private readonly AppDbContext _context;

        public MatchingViewModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MatchingViewModels
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.MatchingViewModel.Include(m => m.Investors).Include(m => m.Presenters).Include(m => m.Sector);
            return View(await appDbContext.ToListAsync());
        }



     
       
        // GET: MatchingViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MatchingViewModel == null)
            {
                return NotFound();
            }

            var matchingViewModel = await _context.MatchingViewModel
                .Include(m => m.Investors)
                .Include(m => m.Presenters)
                .Include(m => m.Sector)
                .FirstOrDefaultAsync(m => m.MV_Id == id);
            if (matchingViewModel == null)
            {
                return NotFound();
            }

            return View(matchingViewModel);
        }

        // GET: MatchingViewModels/Create
        public IActionResult Create()
        {
            ViewData["Investor_Id"] = new SelectList(_context.Investors, "Investor_Id", "Name");
            ViewData["Presenter_Id"] = new SelectList(_context.Presenters, "Presenter_Id", "Name");
            ViewData["Sector_Id"] = new SelectList(_context.Sectors, "Sector_Id", "Name");

            return View();
        }

        // POST: MatchingViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MV_Id,Investor_Id,Sector_Id,Presenter_Id")] MatchingViewModel matchingViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matchingViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Investor_Id"] = new SelectList(_context.Investors, "Investor_Id", "Name", matchingViewModel.Investor_Id);
            ViewData["Presenter_Id"] = new SelectList(_context.Presenters, "Presenter_Id", "Name", matchingViewModel.Presenter_Id);
            ViewData["Sector_Id"] = new SelectList(_context.Sectors, "Sector_Id", "Name", matchingViewModel.Sector_Id);

            return View(matchingViewModel);
        }

        // GET: MatchingViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MatchingViewModel == null)
            {
                return NotFound();
            }

            var matchingViewModel = await _context.MatchingViewModel.FindAsync(id);
            if (matchingViewModel == null)
            {
                return NotFound();
            }
            ViewData["Investor_Id"] = new SelectList(_context.Investors, "Investor_Id", "Name", matchingViewModel.Investor_Id);
            ViewData["Presenter_Id"] = new SelectList(_context.Presenters, "Presenter_Id", "Name", matchingViewModel.Presenter_Id);
            ViewData["Sector_Id"] = new SelectList(_context.Sectors, "Sector_Id", "Name", matchingViewModel.Sector_Id);

            return View(matchingViewModel);
        }

        // POST: MatchingViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MV_Id,Investor_Id,Sector_Id,Presenter_Id")] MatchingViewModel matchingViewModel)
        {
            if (id != matchingViewModel.MV_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matchingViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchingViewModelExists(matchingViewModel.MV_Id))
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
            ViewData["Investor_Id"] = new SelectList(_context.Investors, "Investor_Id", "Name", matchingViewModel.Investor_Id);
            ViewData["Presenter_Id"] = new SelectList(_context.Presenters, "Presenter_Id", "Name", matchingViewModel.Presenter_Id);
            ViewData["Sector_Id"] = new SelectList(_context.Sectors, "Sector_Id", "Name", matchingViewModel.Sector_Id);

            return View(matchingViewModel);
        }

        // GET: MatchingViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MatchingViewModel == null)
            {
                return NotFound();
            }

            var matchingViewModel = await _context.MatchingViewModel
                .Include(m => m.Investors)
                .Include(m => m.Presenters)
                .Include(m => m.Sector)
                .FirstOrDefaultAsync(m => m.MV_Id == id);
            if (matchingViewModel == null)
            {
                return NotFound();
            }

            return View(matchingViewModel);
        }

        // POST: MatchingViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MatchingViewModel == null)
            {
                return Problem("Entity set 'AppDbContext.MatchingViewModel'  is null.");
            }
            var matchingViewModel = await _context.MatchingViewModel.FindAsync(id);
            if (matchingViewModel != null)
            {
                _context.MatchingViewModel.Remove(matchingViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchingViewModelExists(int id)
        {
          return (_context.MatchingViewModel?.Any(e => e.MV_Id == id)).GetValueOrDefault();
        }
    }
}
