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
    public class Sector_PresenterController : Controller
    {
        private readonly AppDbContext _context;

        public Sector_PresenterController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Sector_Presenter
        public async Task<IActionResult> Index(string? sreachvalue)
        {

            if (sreachvalue != null)
            {
                return View(_context.Sectors.Where(x => x.Name.Contains(sreachvalue)).ToList());
            }

            else
            {
                var cats = _context.Sector_Presenters.Include(s => s.Presenter).Include(s => s.Sector);


                return View(cats);
            }


        }

        // GET: Sector_Presenter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sector_Presenters == null)
            {
                return NotFound();
            }

            var sector_Presenter = await _context.Sector_Presenters
                .Include(s => s.Presenter)
                .Include(s => s.Sector)
                .FirstOrDefaultAsync(m => m.Sector_Presenter_Id == id);
            if (sector_Presenter == null)
            {
                return NotFound();
            }

            return View(sector_Presenter);
        }

        // GET: Sector_Presenter/Create
        public IActionResult Create()
        {
            ViewData["Presenter_Id"] = new SelectList(_context.Presenters, "Presenter_Id", "Name");
            ViewData["Sector_Id"] = new SelectList(_context.Sectors, "Sector_Id", "Name");
            return View();
        }

        // POST: Sector_Presenter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sector_Presenter_Id,Presenter_Id,FromDate,ToDate,Sector_Id")] Sector_Presenter sector_Presenter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sector_Presenter);
                await _context.SaveChangesAsync();
                TempData["CreateMessage"] = "Hotel Created Successfully !";

                return RedirectToAction(nameof(Index));
            }
            ViewData["Presenter_Id"] = new SelectList(_context.Presenters, "Presenter_Id", "Name", sector_Presenter.Presenter_Id);
            ViewData["Sector_Id"] = new SelectList(_context.Sectors, "Sector_Id", "Name", sector_Presenter.Sector_Id);
            return View(sector_Presenter);
        }

        // GET: Sector_Presenter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sector_Presenters == null)
            {
                return NotFound();
            }

            var sector_Presenter = await _context.Sector_Presenters.FindAsync(id);
            if (sector_Presenter == null)
            {
                return NotFound();
            }
            ViewData["Presenter_Id"] = new SelectList(_context.Presenters, "Presenter_Id", "Name", sector_Presenter.Presenter_Id);
            ViewData["Sector_Id"] = new SelectList(_context.Sectors, "Sector_Id", "Name", sector_Presenter.Sector_Id);
            return View(sector_Presenter);
        }

        // POST: Sector_Presenter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sector_Presenter_Id,Presenter_Id,FromDate,ToDate,Sector_Id")] Sector_Presenter sector_Presenter)
        {
            if (id != sector_Presenter.Sector_Presenter_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sector_Presenter);
                    await _context.SaveChangesAsync();
                    TempData["EditMessage"] = "Hotel Edit Successfully !";

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Sector_PresenterExists(sector_Presenter.Sector_Presenter_Id))
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
            ViewData["Presenter_Id"] = new SelectList(_context.Presenters, "Presenter_Id", "Name", sector_Presenter.Presenter_Id);
            ViewData["Sector_Id"] = new SelectList(_context.Sectors, "Sector_Id", "Name", sector_Presenter.Sector_Id);
            return View(sector_Presenter);
        }

        // GET: Sector_Presenter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sector_Presenters == null)
            {
                return NotFound();
            }

            var sector_Presenter = await _context.Sector_Presenters
                .Include(s => s.Presenter)
                .Include(s => s.Sector)
                .FirstOrDefaultAsync(m => m.Sector_Presenter_Id == id);
            if (sector_Presenter == null)
            {
                return NotFound();
            }

            return View(sector_Presenter);
        }

        // POST: Sector_Presenter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sector_Presenters == null)
            {
                return Problem("Entity set 'AppDbContext.Sector_Presenters'  is null.");
            }
            var sector_Presenter = await _context.Sector_Presenters.FindAsync(id);
            if (sector_Presenter != null)
            {
                _context.Sector_Presenters.Remove(sector_Presenter);
            }
            
            await _context.SaveChangesAsync();
            TempData["DeleteMessage"] = "Hotel Delete Successfully !";

            return RedirectToAction(nameof(Index));
        }

        private bool Sector_PresenterExists(int id)
        {
          return (_context.Sector_Presenters?.Any(e => e.Sector_Presenter_Id == id)).GetValueOrDefault();
        }
    }
}
