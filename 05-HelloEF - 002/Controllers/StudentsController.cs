using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelloEF;
using HelloEF.DomainModels;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace HelloEF.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            //eagerly Load Department for each student retrieved from database.
            //this will generate e JOIN (inner or left) query between Students and Departments table.
            var schoolContext = _context.Students.Include(s => s.Department);

            //we are composing our query step by step. We can also apply AsNoTracking in the above line.
            //b/c we are in a read-only scenario(only need the data to display them and not change their state like inserting or updating)
            //we don't have to track them and load into the changeTracker.
            //CHECK .AsNoTracking description for more, by hovering the mouse above the method.
            var studentAsNoTracking = schoolContext.AsNoTracking();
            
            var result= await studentAsNoTracking.ToListAsync();

            var changeTrackerEntries = _context.ChangeTracker.Entries().ToList();


            return View(result);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            //Using AsNoTracking on read-only scenarios is a very good practice.
            var student = await _context.Students.AsNoTracking()
                .Include(s => s.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Departments"] = new SelectList(await _context.Departments.AsNoTracking().ToListAsync(), "Id", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,Age,YearsOfExperience,AverageSalary,LevelOfExpertise,Address,DepartmentId")] Student student)
        {
            if (ModelState.IsValid)
            {
                var state = _context.Entry(student).State; //<< Detached

                _context.Add(student);

                state = _context.Entry(student).State; //<< Added

                await _context.SaveChangesAsync();

                state = _context.Entry(student).State; //<< Unchanged (means, the entity in DB and ChangeTracker is the same)

                return RedirectToAction(nameof(Index));
            }

            ViewData["Departments"] = new SelectList(await _context.Departments.AsNoTracking().ToListAsync(), "Id", "Name", student.DepartmentId);

            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            //FindAsync checks for existing prop in ChangeTracker
            var student = await _context.Students.FindAsync(id);

            ////FirstOrDefault bypasses ChangeTracker and runs the query against DB directly
            //var student2 = await _context.Students.FirstOrDefaultAsync(p=>p.Id==id);

            //var student3 = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            ViewData["Departments"] = new SelectList(await _context.Departments.AsNoTracking().ToListAsync(), "Id", "Name", student.DepartmentId);

            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,Age,YearsOfExperience,AverageSalary,LevelOfExpertise,Address,DepartmentId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //var state = _context.Entry(student).State; //<< Detached
                    
                    _context.Update(student);
                     
                    //state = _context.Entry(student).State; //<< Modified

                    await _context.SaveChangesAsync();

                    //state = _context.Entry(student).State; //<< Unchanged (means, the entity in DB and ChangeTracker is the same)
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                    .Where(y=>y.Count>0)
                    .ToList();
            }
            
            ViewData["Departments"] = new SelectList(await _context.Departments.AsNoTracking().ToListAsync(), "Id", "Name", student.DepartmentId);

            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Department)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'SchoolContext.Students'  is null.");
            }

            var student = await _context.Students.FindAsync(id);

            if (student != null)
            {
                _context.Students.Remove(student);
                
                var state = _context.Entry(student).State; //<< Deleted
            }
            
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
          return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
