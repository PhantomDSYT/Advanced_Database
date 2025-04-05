using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AD_DB_Project.Models;
using AD_DB_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace AD_DB_Project.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class EmployeesController : Controller
    {
        private readonly AD_DB_ProjectContext _context;

        public EmployeesController(AD_DB_ProjectContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Trn == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["AirportCode"] = new SelectList(_context.Airport, "AirportCode", "AirportCode");
            List<SelectListItem> roles = new List<SelectListItem>()
            {
                new SelectListItem { Value = "Standard", Text = "Standard" },
                new SelectListItem { Value = "Technician", Text = "Technician" },
                new SelectListItem { Value = "Traffic Controller", Text = "Traffic Controller" }
            };

            ViewBag.empRoles = roles;
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

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateViewModel employee)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee
                {
                    Trn = employee.Trn,
                    FName = employee.FName,
                    MName = employee.MName,
                    LName = employee.LName,
                    Address = employee.Address,
                    Salary = employee.Salary,
                    Tel = employee.Tel
                };
                _context.Add(emp);

                if(employee.EmployeeRole == "Technician")
                {
                    Technician tech = new Technician
                    {
                        Trn = employee.Trn,
                        Expertise = employee.TechExpertise,
                        Restriction = employee.TechRestriction
                    };
                    _context.Add(tech);
                }

                if(employee.EmployeeRole == "Traffic Controller")
                {
                    TrafficController trafficController = new TrafficController()
                    {
                        Trn = employee.Trn,
                        Exam = employee.ExamDate
                    };
                    _context.Add(trafficController);
                }

                WorkStaff staff = new WorkStaff
                {
                    Trn = employee.Trn,
                    AirportCode = employee.AirportCode
                };

                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Trn,FName,LName,MName,Salary,Address,Tel")] Employee employee)
        {
            if (id != employee.Trn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Trn))
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
            return View(employee);
        }

        [Authorize(Roles = "Admin")]
        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Trn == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [Authorize(Roles = "Admin")]
        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Trn == id);
        }

        public IActionResult AddUnion()
        {
            ViewData["Trn"] = new SelectList(_context.Employee, "Trn", "Trn");
            ViewData["UMembership"] = new SelectList(_context.WorkerUnion, "UMembership", "UMembership");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUnion(UnionUpdateVieweModel model)
        {
            if(ModelState.IsValid)
            {
                Category category = new Category()
                {
                    Trn = model.Trn,
                    UMembership = model.Membership
                };
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(model);
        }
    }
}
