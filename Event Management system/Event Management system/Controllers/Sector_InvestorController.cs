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
    public class Sector_InvestorController : Controller
    {
        private readonly AppDbContext _context;

        public Sector_InvestorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Sector_Investor
        public async Task<IActionResult> Index()
        {

           var appDbContext = _context.Sector_Investors.Include(s => s.Investor).Include(s => s.Sector);
              return View(await appDbContext.ToListAsync());


        }
        public IActionResult Information(string? searchname, string? searchsector, DateTime? start, DateTime? end)
        {
 


                var ee = (from fac in _context.Sector_Presenters
                      select new Sector_Presenter()
                      {
                          Sector_Presenter_Id = fac.Sector_Presenter_Id,
                          Sector = fac.Sector,
                          Presenter = fac.Presenter,
                          FromDate = fac.FromDate,
                          ToDate = fac.ToDate,

                      });
            if (searchname != null && searchsector == null && start == null && end == null)
            {
                return View(View());
            }
            else if (searchname != null && searchsector == null && start == null && end == null)
            {
                var kk = (from fac in _context.Sector_Presenters
                          join sem in _context.Sector_Presenters on fac.Sector_Id equals sem.Sector_Id
                          where fac.FromDate < sem.ToDate && fac.ToDate > sem.FromDate && fac.Presenter.Name.Contains(searchname)
                          select new Sector_Presenter()
                          {
                              Sector_Presenter_Id = fac.Sector_Presenter_Id,
                              Sector = fac.Sector,
                              Presenter = fac.Presenter,
                              FromDate = fac.FromDate,
                              ToDate = fac.ToDate,

                          });

                return View(kk);

            }
            else if (searchname != null && searchsector != null && start == null && end == null)
            {

                var rr = (from fac in _context.Sector_Investors
                          join sem in _context.Sector_Presenters on fac.Sector_Id equals sem.Sector_Id
                          where fac.FromDate < sem.ToDate && fac.ToDate > sem.FromDate && fac.Investor.Name.Contains(searchname) && fac.Sector.Name.Contains(searchsector)
                          select new Sector_Presenter()
                          {
                              Sector_Presenter_Id = sem.Sector_Presenter_Id,
                              Sector = sem.Sector,
                              Presenter = sem.Presenter,
                              FromDate = sem.FromDate,
                              ToDate = sem.ToDate,

                          });
                return View(rr);

            }

            else if (searchname == null && searchsector != null && start == null && end == null)
            {

                var qq = (from fac in _context.Sector_Investors
                          join sem in _context.Sector_Presenters on fac.Sector_Id equals sem.Sector_Id
                          where fac.FromDate < sem.ToDate && fac.ToDate > sem.FromDate && fac.Sector.Name.Contains(searchsector)
                          select new Sector_Presenter()
                          {
                              Sector_Presenter_Id = sem.Sector_Presenter_Id,
                              Sector = sem.Sector,
                              Presenter = sem.Presenter,
                              FromDate = sem.FromDate,
                              ToDate = sem.ToDate,

                          });
                return View(qq);

            }

            else if (searchname == null && searchsector == null && start != null && end != null)
            {

                var mm = (from fac in _context.Sector_Investors
                          join sem in _context.Sector_Presenters on fac.Sector_Id equals sem.Sector_Id
                          where start < fac.ToDate && end > fac.FromDate
                          select new Sector_Presenter()
                          {
                              Sector_Presenter_Id = sem.Sector_Presenter_Id,
                              Sector = sem.Sector,
                              Presenter = sem.Presenter,
                              FromDate = sem.FromDate,
                              ToDate = sem.ToDate,

                          });
                return View(mm);

            }
            else if (searchname != null && searchsector != null && start != null && end != null)
            {

                var mm = (from fac in _context.Sector_Investors
                          join sem in _context.Sector_Presenters on fac.Sector_Id equals sem.Sector_Id
                          where start < sem.ToDate && end > sem.FromDate && fac.Investor.Name.Contains(searchname) && fac.Sector.Name.Contains(searchsector)
                          select new Sector_Presenter()
                          {
                              Sector_Presenter_Id = sem.Sector_Presenter_Id,
                              Sector = sem.Sector,
                              Presenter = sem.Presenter,
                              FromDate = sem.FromDate,
                              ToDate = sem.ToDate,

                          });



                return View(mm);

            }
            else if (searchname != null && searchsector == null && start != null && end != null)
            {

                var mm = (from fac in _context.Sector_Investors
                          join sem in _context.Sector_Presenters on fac.Sector_Id equals sem.Sector_Id
                          where start < fac.ToDate && end > fac.FromDate && fac.Investor.Name.Contains(searchname)
                          select new Sector_Presenter()
                          {
                              Sector_Presenter_Id = sem.Sector_Presenter_Id,
                              Sector = sem.Sector,
                              Presenter = sem.Presenter,
                              FromDate = sem.FromDate,
                              ToDate = sem.ToDate,

                          });
                return View(mm);

            }
            else if (searchname == null && searchsector != null && start != null && end != null)
            {

                var mm = (from fac in _context.Sector_Presenters
                          join sem in _context.Sector_Presenters on fac.Sector_Id equals sem.Sector_Id
                          where start < fac.ToDate && end > fac.FromDate && fac.Sector.Name.Contains(searchsector)
                          select new Sector_Presenter()
                          {
                              Sector_Presenter_Id = sem.Sector_Presenter_Id,
                              Sector = sem.Sector,
                              Presenter = sem.Presenter,
                              FromDate = sem.FromDate,
                              ToDate = sem.ToDate,

                          });
                return View(mm);

            }

            return View(ee);

        }
        // GET: Sector_Investor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sector_Investors == null)
            {
                return NotFound();
            }

            var sector_Investor = await _context.Sector_Investors
                .Include(s => s.Investor)
                .Include(s => s.Sector)
                .FirstOrDefaultAsync(m => m.Sector_Investor_Id == id);
            if (sector_Investor == null)
            {
                return NotFound();
            }

            return View(sector_Investor);
        }

        // GET: Sector_Investor/Create
        public IActionResult Create()
        {
            ViewData["Investor_Id"] = new SelectList(_context.Investors, "Investor_Id", "Name");
            ViewData["Sector_Id"] = new SelectList(_context.Sectors, "Sector_Id", "Name");
            return View();
        }

        // POST: Sector_Investor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sector_Investor_Id,Investor_Id,FromDate,ToDate,Sector_Id")] Sector_Investor sector_Investor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sector_Investor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Investor_Id"] = new SelectList(_context.Investors, "Investor_Id", "Name", sector_Investor.Investor_Id);
            ViewData["Sector_Id"] = new SelectList(_context.Sectors, "Sector_Id", "Name", sector_Investor.Sector_Id);
            return View(sector_Investor);
        }

        // GET: Sector_Investor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sector_Investors == null)
            {
                return NotFound();
            }

            var sector_Investor = await _context.Sector_Investors.FindAsync(id);
            if (sector_Investor == null)
            {
                return NotFound();
            }
            ViewData["Investor_Id"] = new SelectList(_context.Investors, "Investor_Id", "Name", sector_Investor.Investor_Id);
            ViewData["Sector_Id"] = new SelectList(_context.Sectors, "Sector_Id", "Name", sector_Investor.Sector_Id);
            return View(sector_Investor);
        }

        // POST: Sector_Investor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sector_Investor_Id,Investor_Id,FromDate,ToDate,Sector_Id")] Sector_Investor sector_Investor)
        {
            if (id != sector_Investor.Sector_Investor_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sector_Investor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Sector_InvestorExists(sector_Investor.Sector_Investor_Id))
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
            ViewData["Investor_Id"] = new SelectList(_context.Investors, "Investor_Id", "Name", sector_Investor.Investor_Id);
            ViewData["Sector_Id"] = new SelectList(_context.Sectors, "Sector_Id", "Name", sector_Investor.Sector_Id);
            return View(sector_Investor);
        }

        // GET: Sector_Investor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sector_Investors == null)
            {
                return NotFound();
            }

            var sector_Investor = await _context.Sector_Investors
                .Include(s => s.Investor)
                .Include(s => s.Sector)
                .FirstOrDefaultAsync(m => m.Sector_Investor_Id == id);
            if (sector_Investor == null)
            {
                return NotFound();
            }

            return View(sector_Investor);
        }

        // POST: Sector_Investor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sector_Investors == null)
            {
                return Problem("Entity set 'AppDbContext.Sector_Investors'  is null.");
            }
            var sector_Investor = await _context.Sector_Investors.FindAsync(id);
            if (sector_Investor != null)
            {
                _context.Sector_Investors.Remove(sector_Investor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetMatch(int searchpre)
        {

            var presenter = _context.Sector_Presenters.Where(s => s.Sector_Presenter_Id == searchpre);


            var roomsbooking = from i in _context.Sector_Investors
                               from room in _context.Rooms
                               join p in presenter on i.Sector_Id equals p.Sector_Id
                               where i.FromDate < p.ToDate && i.ToDate > p.FromDate &&
                               ((room.FromDate >= i.FromDate) && (room.FromDate <= i.ToDate)) &&
                               ((room.ToDate >= i.FromDate) && (room.ToDate <= i.ToDate)) &&
                               ((room.FromDate >= p.FromDate) && (room.FromDate <= p.ToDate)) &&
                               ((room.ToDate >= p.FromDate) && (room.ToDate <= p.ToDate))
                               select new Room
                               {
                                   Name = room.Name,
                                   FromDate = room.FromDate,
                                   ToDate = room.ToDate
                               };

            return View(roomsbooking);



        }
        private bool Sector_InvestorExists(int id)
        {
          return (_context.Sector_Investors?.Any(e => e.Sector_Investor_Id == id)).GetValueOrDefault();
        }
    }
}
