using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace College_Departments
{
    public class CollegeStudentsController : Controller
    {
        private readonly CollegeStudentsContext _context;

        public CollegeStudentsController(CollegeStudentsContext context)
        {
            _context = context;
        }

        // GET: CollegeStudents
        public async Task<IActionResult> Index()
        {
            return View(await _context.CollegeStudents.ToListAsync());
        }
        public async Task<IActionResult> Mechanical()
        {
            return View(await _context.CollegeStudents.Where(x => x.Department == "Mechanical").ToListAsync());
        }
        public async Task<IActionResult> Electrical()
        {
            return View(await _context.CollegeStudents.Where(x => x.Department == "Electrical").ToListAsync());
        }
        public async Task<IActionResult> Civil()
        {
            return View(await _context.CollegeStudents.Where(x => x.Department == "Civil").ToListAsync());
        }
        public async Task<IActionResult> CSE()
        {
            return View(await _context.CollegeStudents.Where(x => x.Department == "CSE").ToListAsync());
        }
        public async Task<IActionResult> ECE()
        {
            return View(await _context.CollegeStudents.Where(x => x.Department == "ECE").ToListAsync());
        }

        // GET: CollegeStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeStudent = await _context.CollegeStudents
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (collegeStudent == null)
            {
                return NotFound();
            }

            return View(collegeStudent);
        }

        // GET: CollegeStudents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CollegeStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentsName,FathersName,MothersName,StudentsAge,Height,Gender,Department,Roll")] CollegeStudent collegeStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collegeStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(collegeStudent);
        }

        // GET: CollegeStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeStudent = await _context.CollegeStudents.FindAsync(id);
            if (collegeStudent == null)
            {
                return NotFound();
            }
            return View(collegeStudent);
        }

        // POST: CollegeStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentsName,FathersName,MothersName,StudentsAge,Height,Gender,Department,Roll")] CollegeStudent collegeStudent)
        {
            if (id != collegeStudent.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collegeStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollegeStudentExists(collegeStudent.StudentId))
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
            return View(collegeStudent);
        }

        // GET: CollegeStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeStudent = await _context.CollegeStudents
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (collegeStudent == null)
            {
                return NotFound();
            }

            return View(collegeStudent);
        }

        // POST: CollegeStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collegeStudent = await _context.CollegeStudents.FindAsync(id);
            _context.CollegeStudents.Remove(collegeStudent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollegeStudentExists(int id)
        {
            return _context.CollegeStudents.Any(e => e.StudentId == id);
        }
    }
}
