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
    public class PresentersController : Controller
    {
        private readonly AppDbContext _context;

        public PresentersController(AppDbContext context)
        {
            _context = context;
        }



        // GET: Presenters
        public async Task<IActionResult> Index()
        {
            return _context.Presenters != null ?
                        View(await _context.Presenters.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Presenters'  is null.");
        }

        


        // GET: Presenters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Presenters == null)
            {
                return NotFound();
            }

            var presenter = await _context.Presenters
                .FirstOrDefaultAsync(m => m.Presenter_Id == id);
            if (presenter == null)
            {
                return NotFound();
            }

            return View(presenter);
        }

        // GET: Presenters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Presenters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Presenter_Id,Name,Mobile")] Presenter presenter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presenter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(presenter);
        }

        // GET: Presenters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Presenters == null)
            {
                return NotFound();
            }

            var presenter = await _context.Presenters.FindAsync(id);
            if (presenter == null)
            {
                return NotFound();
            }
            return View(presenter);
        }

        // POST: Presenters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Presenter_Id,Name,Mobile")] Presenter presenter)
        {
            if (id != presenter.Presenter_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presenter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresenterExists(presenter.Presenter_Id))
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
            return View(presenter);
        }

        // GET: Presenters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Presenters == null)
            {
                return NotFound();
            }

            var presenter = await _context.Presenters
                .FirstOrDefaultAsync(m => m.Presenter_Id == id);
            if (presenter == null)
            {
                return NotFound();
            }

            return View(presenter);
        }

        // POST: Presenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Presenters == null)
            {
                return Problem("Entity set 'AppDbContext.Presenters'  is null.");
            }
            var presenter = await _context.Presenters.FindAsync(id);
            if (presenter != null)
            {
                _context.Presenters.Remove(presenter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresenterExists(int id)
        {
            return (_context.Presenters?.Any(e => e.Presenter_Id == id)).GetValueOrDefault();
        }
    }
}
