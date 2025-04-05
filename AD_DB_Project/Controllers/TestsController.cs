using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AD_DB_Project.Models;
using Microsoft.AspNetCore.Authorization;

namespace AD_DB_Project.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class TestsController : Controller
    {
        private readonly AD_DB_ProjectContext _context;

        public TestsController(AD_DB_ProjectContext context)
        {
            _context = context;
        }

        // GET: Tests
        public async Task<IActionResult> Index()
        {
            var aD_DB_ProjectContext = _context.Test.Include(t => t.RegNumNavigation);
            return View(await aD_DB_ProjectContext.ToListAsync());
        }

        // GET: Tests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Test
                .Include(t => t.RegNumNavigation)
                .FirstOrDefaultAsync(m => m.FaaNum == id);
            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        // GET: Tests/Create
        public IActionResult Create()
        {
            ViewData["RegNum"] = new SelectList(_context.Airplane, "RegNum", "RegNum");
            return View();
        }

        // POST: Tests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FaaNum,Name,MaxScore,Date,Score,TestHours,RegNum")] Test test)
        {
            if (ModelState.IsValid)
            {
                _context.Add(test);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegNum"] = new SelectList(_context.Airplane, "RegNum", "AirportCode", test.RegNum);
            return View(test);
        }

        // GET: Tests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Test.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }
            ViewData["RegNum"] = new SelectList(_context.Airplane, "RegNum", "RegNum", test.RegNum);
            return View(test);
        }

        // POST: Tests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FaaNum,Name,MaxScore,Date,Score,TestHours,RegNum")] Test test)
        {
            if (id != test.FaaNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(test);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestExists(test.FaaNum))
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
            ViewData["RegNum"] = new SelectList(_context.Airplane, "RegNum", "AirportCode", test.RegNum);
            return View(test);
        }

        [Authorize(Roles = "Admin")]
        // GET: Tests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Test
                .Include(t => t.RegNumNavigation)
                .FirstOrDefaultAsync(m => m.FaaNum == id);
            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        [Authorize(Roles = "Admin")]
        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var test = await _context.Test.FindAsync(id);
            _context.Test.Remove(test);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestExists(int id)
        {
            return _context.Test.Any(e => e.FaaNum == id);
        }
    }
}
