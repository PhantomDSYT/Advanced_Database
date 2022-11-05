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
    public class WorkerUnionsController : Controller
    {
        private readonly AD_DB_ProjectContext _context;

        public WorkerUnionsController(AD_DB_ProjectContext context)
        {
            _context = context;
        }

        // GET: WorkerUnions
        public async Task<IActionResult> Index()
        {
            var aD_DB_ProjectContext = _context.WorkerUnion.Include(w => w.UPresidentNavigation);
            return View(await aD_DB_ProjectContext.ToListAsync());
        }

        // GET: WorkerUnions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerUnion = await _context.WorkerUnion
                .Include(w => w.UPresidentNavigation)
                .FirstOrDefaultAsync(m => m.UMembership == id);
            if (workerUnion == null)
            {
                return NotFound();
            }

            return View(workerUnion);
        }

        // GET: WorkerUnions/Create
        public IActionResult Create()
        {
            ViewData["UPresident"] = new SelectList(_context.Employee, "Trn", "Trn");
            return View();
        }

        // POST: WorkerUnions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UMembership,UName,UPresident")] WorkerUnion workerUnion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workerUnion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UPresident"] = new SelectList(_context.Employee, "Trn", "Trn", workerUnion.UPresident);
            return View(workerUnion);
        }

        // GET: WorkerUnions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerUnion = await _context.WorkerUnion.FindAsync(id);
            if (workerUnion == null)
            {
                return NotFound();
            }
            ViewData["UPresident"] = new SelectList(_context.Employee, "Trn", "Trn", workerUnion.UPresident);
            return View(workerUnion);
        }

        // POST: WorkerUnions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UMembership,UName,UPresident")] WorkerUnion workerUnion)
        {
            if (id != workerUnion.UMembership)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workerUnion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerUnionExists(workerUnion.UMembership))
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
            ViewData["UPresident"] = new SelectList(_context.Employee, "Trn", "Trn", workerUnion.UPresident);
            return View(workerUnion);
        }

        // GET: WorkerUnions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerUnion = await _context.WorkerUnion
                .Include(w => w.UPresidentNavigation)
                .FirstOrDefaultAsync(m => m.UMembership == id);
            if (workerUnion == null)
            {
                return NotFound();
            }

            return View(workerUnion);
        }

        // POST: WorkerUnions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var workerUnion = await _context.WorkerUnion.FindAsync(id);
            _context.WorkerUnion.Remove(workerUnion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerUnionExists(string id)
        {
            return _context.WorkerUnion.Any(e => e.UMembership == id);
        }
    }
}
