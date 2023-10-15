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
    public class BookingsController22 : Controller
    {
        private readonly AppDbContext _context;

        public BookingsController22(AppDbContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Bookings.Include(b => b.Investor).Include(b => b.Presenter).Include(b => b.Room);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Investor)
                .Include(b => b.Presenter)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(m => m.Booking_Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }
        public IActionResult Information(int? searchname, int? searchsector, DateTime? start, DateTime? end)
        {
            ViewData["Investor_Id"] = new SelectList(_context.Investors, "Investor_Id", "Name");
            ViewData["Sector_Id"] = new SelectList(_context.Sectors, "Sector_Id", "Name");



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
                          where fac.FromDate < sem.ToDate && fac.ToDate > sem.FromDate && fac.Presenter.Presenter_Id.Equals(searchname)
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
                          where fac.FromDate < sem.ToDate && fac.ToDate > sem.FromDate && fac.Investor.Investor_Id.Equals(searchname) && fac.Sector.Sector_Id.Equals(searchsector)
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
                          where fac.FromDate < sem.ToDate && fac.ToDate > sem.FromDate && fac.Sector.Sector_Id.Equals(searchsector)
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
                          where start < sem.ToDate && end > sem.FromDate && fac.Investor.Investor_Id.Equals(searchname) && fac.Sector.Sector_Id.Equals(searchsector)
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
                          where start < fac.ToDate && end > fac.FromDate && fac.Investor.Investor_Id.Equals(searchname)
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
                          where start < fac.ToDate && end > fac.FromDate && fac.Sector.Sector_Id.Equals(searchsector)
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

        // GET: Bookings/Create
   

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        public IActionResult Create(int? searchname, int? searchpre)
        {
            Booking booking = new Booking();
            booking.Presenter_Id = (int)searchpre;
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(booking);
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
            // GET: Bookings/Edit/5
            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["Investor_Id"] = new SelectList(_context.Investors, "Investor_Id", "Name", booking.Investor_Id);
            ViewData["Presenter_Id"] = new SelectList(_context.Presenters, "Presenter_Id", "Name", booking.Presenter_Id);
            ViewData["Room_Id"] = new SelectList(_context.Rooms, "Room_Id", "Name", booking.Room_Id);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Booking_Id,Investor_Id,Presenter_Id,Room_Id")] Booking booking)
        {
            if (id != booking.Booking_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.Booking_Id))
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
            ViewData["Investor_Id"] = new SelectList(_context.Investors, "Investor_Id", "Name", booking.Investor_Id);
            ViewData["Presenter_Id"] = new SelectList(_context.Presenters, "Presenter_Id", "Name", booking.Presenter_Id);
            ViewData["Room_Id"] = new SelectList(_context.Rooms, "Room_Id", "Name", booking.Room_Id);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Investor)
                .Include(b => b.Presenter)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(m => m.Booking_Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bookings == null)
            {
                return Problem("Entity set 'AppDbContext.Bookings'  is null.");
            }
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
          return (_context.Bookings?.Any(e => e.Booking_Id == id)).GetValueOrDefault();
        }
    }
}
