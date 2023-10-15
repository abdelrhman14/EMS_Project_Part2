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
    public class RoomsController22 : Controller
    {
        private readonly AppDbContext _context;

        public RoomsController22(AppDbContext context)
        {
            _context = context;
        }
       // var appDbContext = _context.Rooms.Include(r => r.Hotel);
         //   return View(await appDbContext.ToListAsync());
        // GET: Rooms


        public async Task<IActionResult> Index(string? sreachvalue, string? sreachss)
        {
            var cats = _context.Rooms.Include(r => r.Hotel);
   
                return View(cats);
           
        }

       
        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Hotel)
                .FirstOrDefaultAsync(m => m.Room_Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create(string? sreachvalue)
        {
            ViewData["Hotel_Id"] = new SelectList(_context.Hotels, "Hotel_Id", "Name");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Room_Id,Name,FromDate,ToDate,Status,Hotel_Id")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                TempData["CreateMessage"] = "Hotel Created Successfully !";

                return RedirectToAction(nameof(Index));
            }
            ViewData["Hotel_Id"] = new SelectList(_context.Hotels, "Hotel_Id", "Name", room.Hotel_Id);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["Hotel_Id"] = new SelectList(_context.Hotels, "Hotel_Id", "Name", room.Hotel_Id);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Room_Id,Name,FromDate,ToDate,Status,Hotel_Id")] Room room)
        {
            if (id != room.Room_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                    TempData["EditMessage"] = "Hotel Edit Successfully !";

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Room_Id))
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
            ViewData["Hotel_Id"] = new SelectList(_context.Hotels, "Hotel_Id", "Name", room.Hotel_Id);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Hotel)
                .FirstOrDefaultAsync(m => m.Room_Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rooms == null)
            {
                return Problem("Entity set 'AppDbContext.Rooms'  is null.");
            }
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);

            }
            
            await _context.SaveChangesAsync();
            TempData["DeleteMessage"] = "Hotel Delete Successfully !";

            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
          return (_context.Rooms?.Any(e => e.Room_Id == id)).GetValueOrDefault();
        }
    }
}
