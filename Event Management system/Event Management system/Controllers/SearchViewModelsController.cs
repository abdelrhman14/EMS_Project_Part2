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
    public class SearchViewModelsController : Controller
    {
        private readonly AppDbContext _context;

        public SearchViewModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SearchViewModels
        public async Task<IActionResult> Index()
        {
              return _context.SearchViewModels != null ? 
                          View(await _context.SearchViewModels.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.SearchViewModels'  is null.");
        }

        // GET: SearchViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SearchViewModels == null)
            {
                return NotFound();
            }

            var searchViewModel = await _context.SearchViewModels
                .FirstOrDefaultAsync(m => m.SearchViewModel_Id == id);
            if (searchViewModel == null)
            {
                return NotFound();
            }

            return View(searchViewModel);
        }

        // GET: SearchViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

       
       

        // POST: SearchViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SearchViewModel_Id,FromDate,ToDate")] SearchViewModel searchViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(searchViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(searchViewModel);
        }

        // GET: SearchViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SearchViewModels == null)
            {
                return NotFound();
            }

            var searchViewModel = await _context.SearchViewModels.FindAsync(id);
            if (searchViewModel == null)
            {
                return NotFound();
            }
            return View(searchViewModel);
        }

        // POST: SearchViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SearchViewModel_Id,FromDate,ToDate")] SearchViewModel searchViewModel)
        {
            if (id != searchViewModel.SearchViewModel_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(searchViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SearchViewModelExists(searchViewModel.SearchViewModel_Id))
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
            return View(searchViewModel);
        }

        // GET: SearchViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SearchViewModels == null)
            {
                return NotFound();
            }

            var searchViewModel = await _context.SearchViewModels
                .FirstOrDefaultAsync(m => m.SearchViewModel_Id == id);
            if (searchViewModel == null)
            {
                return NotFound();
            }

            return View(searchViewModel);
        }

        // POST: SearchViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SearchViewModels == null)
            {
                return Problem("Entity set 'AppDbContext.SearchViewModels'  is null.");
            }
            var searchViewModel = await _context.SearchViewModels.FindAsync(id);
            if (searchViewModel != null)
            {
                _context.SearchViewModels.Remove(searchViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SearchViewModelExists(int id)
        {
          return (_context.SearchViewModels?.Any(e => e.SearchViewModel_Id == id)).GetValueOrDefault();
        }
    }
}
