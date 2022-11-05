using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AD_DB_Project.Models;

namespace AD_DB_Project.Controllers
{
    public class AirplanesController : Controller
    {
        private readonly AD_DB_ProjectContext _context;

        public AirplanesController(AD_DB_ProjectContext context)
        {
            _context = context;
        }

        // GET: Airplanes
        public async Task<IActionResult> Index()
        {
            var aD_DB_ProjectContext = _context.Airplane.Include(a => a.AirportCodeNavigation);
            return View(await aD_DB_ProjectContext.ToListAsync());
        }

        // GET: Airplanes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airplane = await _context.Airplane
                .Include(a => a.AirportCodeNavigation)
                .FirstOrDefaultAsync(m => m.RegNum == id);
            if (airplane == null)
            {
                return NotFound();
            }

            return View(airplane);
        }

        // GET: Airplanes/Create
        public IActionResult Create()
        {
            ViewData["AirportCode"] = new SelectList(_context.Airport, "AirportCode", "AirportCode");
            List<SelectListItem> models = new List<SelectListItem>()
            {
                new SelectListItem { Value = "Airbus A320", Text = "Airbus A320" },
                new SelectListItem { Value = "Airbus A330", Text = "Airbus A330" },
                new SelectListItem { Value = "Boeing 737", Text = "Boeing 737" },
                new SelectListItem { Value = "Boeing 777", Text = "Boeing 777" }
            };

            ViewBag.Airplane = models;
            return View();
        }

        // POST: Airplanes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegNum,Company,Model,AirportCode")] Airplane airplane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airplane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AirportCode"] = new SelectList(_context.Airport, "AirportCode", "AirportCode", airplane.AirportCode);
            return View(airplane);
        }

        // GET: Airplanes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airplane = await _context.Airplane.FindAsync(id);
            if (airplane == null)
            {
                return NotFound();
            }
            ViewData["AirportCode"] = new SelectList(_context.Airport, "AirportCode", "AirportCode", airplane.AirportCode);
            return View(airplane);
        }

        // POST: Airplanes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegNum,Company,Model,AirportCode")] Airplane airplane)
        {
            if (id != airplane.RegNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airplane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirplaneExists(airplane.RegNum))
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
            ViewData["AirportCode"] = new SelectList(_context.Airport, "AirportCode", "AirportCode", airplane.AirportCode);
            return View(airplane);
        }

        // GET: Airplanes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airplane = await _context.Airplane
                .Include(a => a.AirportCodeNavigation)
                .FirstOrDefaultAsync(m => m.RegNum == id);
            if (airplane == null)
            {
                return NotFound();
            }

            return View(airplane);
        }

        // POST: Airplanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var airplane = await _context.Airplane.FindAsync(id);
            _context.Airplane.Remove(airplane);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirplaneExists(int id)
        {
            return _context.Airplane.Any(e => e.RegNum == id);
        }
    }
}
