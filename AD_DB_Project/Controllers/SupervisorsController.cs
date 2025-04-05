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
    public class SupervisorsController : Controller
    {
        private readonly AD_DB_ProjectContext _context;

        public SupervisorsController(AD_DB_ProjectContext context)
        {
            _context = context;
        }

        // GET: Supervisors
        public async Task<IActionResult> Index()
        {
            var aD_DB_ProjectContext = _context.Supervisor.Include(s => s.TrnNavigation);
            return View(await aD_DB_ProjectContext.ToListAsync());
        }

        // GET: Supervisors/Details/5
        public async Task<IActionResult> Details(int? id, DateTime date, int emp)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisor.FindAsync(id, date, emp);
            if (supervisor == null)
            {
                return NotFound();
            }

            return View(supervisor);
        }

        // GET: Supervisors/Create
        public IActionResult Create()
        {
            ViewData["Trn"] = new SelectList(_context.Employee, "Trn", "Trn");
            return View();
        }

        // POST: Supervisors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Trn,Start,Employee,EndDate")] Supervisor supervisor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supervisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Trn"] = new SelectList(_context.Employee, "Trn", "Trn", supervisor.Trn);
            return View(supervisor);
        }

        // GET: Supervisors/Edit/5
        public async Task<IActionResult> Edit(int? id, DateTime date, int emp)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisor.FindAsync(id, date, emp);
            if (supervisor == null)
            {
                return NotFound();
            }
            ViewData["Trn"] = new SelectList(_context.Employee, "Trn", "Trn", supervisor.Trn);
            return View(supervisor);
        }

        // POST: Supervisors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Trn,Start,Employee,EndDate")] Supervisor supervisor)
        {
            if (id != supervisor.Trn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supervisor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupervisorExists(supervisor.Trn))
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
            ViewData["Trn"] = new SelectList(_context.Employee, "Trn", "Trn", supervisor.Trn);
            return View(supervisor);
        }

        [Authorize(Roles = "Admin")]
        // GET: Supervisors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisor
                .Include(s => s.TrnNavigation)
                .FirstOrDefaultAsync(m => m.Trn == id);
            if (supervisor == null)
            {
                return NotFound();
            }

            return View(supervisor);
        }

        [Authorize(Roles = "Admin")]
        // POST: Supervisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supervisor = await _context.Supervisor.FindAsync(id);
            _context.Supervisor.Remove(supervisor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupervisorExists(int id)
        {
            return _context.Supervisor.Any(e => e.Trn == id);
        }
    }
}
