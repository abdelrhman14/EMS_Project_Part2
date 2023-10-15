using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Event_Management_system.Data;
using Event_Management_system.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data.SqlTypes;
using System.Globalization;

namespace Event_Management_system.Controllers
{
    public class Sector_InvestorController22 : Controller
    {
        private readonly AppDbContext _context;

        public Sector_InvestorController22(AppDbContext context)
        {
            _context = context;
        }
     
        // GET: Sector_Investor
        [HttpGet]
      

    //    [HttpGet]
       // public IActionResult GetData(DateTime? start, DateTime? end)
    //    {

           // var ViewModel2 = from f in _context.Sector_Investors
         //                    join s in _context.Sector_Presenter on f.Sector_Id equals s.Sector_Id
        //                     where start < s.ToDate && end > s.FromDate
         //                    select new MatchingViewModel { sector_investor = f, sector_presenter = s };
       //     return View(ViewModel2);

     //   }


    //    [HttpGet]
    //   public IActionResult GetMatch(int? Se_id)
    //   {

         //   var ViewModel = from fac in _context.Sector_Investors
                       //     join sem in _context.Sector_Presenters on fac.Sector_Id equals sem.Sector_Id
                         //   where fac.FromDate < sem.ToDate && fac.ToDate > sem.FromDate && fac.Sector_Id==Se_id
                         //   select new MatchingViewModel { sector_investor = fac, sector_presenter = sem };
           // return View(ViewModel); 

          

    //   }


  

        // GET: Sector_Investor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sector_Investors == null)
            {
                return NotFound();
            }

            var sector_Investor = await _context.Sector_Investors
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
            ViewData["Sector_Id"] = new SelectList(_context.Sectors, "Sector_Id", "Name");
            ViewData["Investor_Id"] = new SelectList(_context.Investors, "Investor_Id", "Name");

            return View();
        }

        // POST: Sector_Investor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sector_Investor_Id,Investor_Id,Sector_Id,FromDate,ToDate")] Sector_Investor sector_Investor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sector_Investor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
          //  ViewData["Sector_Id"] = new SelectList(_context.Sectors, "Sector_Id", "Name", sector_Investor.Sector_Id);
          //  ViewData["Investor_Id"] = new SelectList(_context.Investors, "Investor_Id", "Name", sector_Investor.Investor_Id);

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
            return View(sector_Investor);
        }

        // POST: Sector_Investor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sector_Investor_Id,Investor_Id,Sector_Id,FromDate,ToDate")] Sector_Investor sector_Investor)
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

        private bool Sector_InvestorExists(int id)
        {
          return (_context.Sector_Investors?.Any(e => e.Sector_Investor_Id == id)).GetValueOrDefault();
        }
    }
}
