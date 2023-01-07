using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication5last100.Data;
using WebApplication5last100.Models;

namespace WebApplication5last100.Controllers
{
    public class CourseNamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseNamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CourseNames
        [Authorize]

        public async Task<IActionResult> Index()
        {
            return View(await _context.CourseName.ToListAsync());
        }

        // GET: CourseNames/Details/5
        [Authorize]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CourseName == null)
            {
                return NotFound();
            }

            var courseName = await _context.CourseName
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseName == null)
            {
                return NotFound();
            }

            return View(courseName);
        }

        // GET: CourseNames/Create
        [Authorize(Roles = "Admin")]

        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseNames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create([Bind("Id,Name")] CourseName courseName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseName);
        }

        // GET: CourseNames/Edit/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CourseName == null)
            {
                return NotFound();
            }

            var courseName = await _context.CourseName.FindAsync(id);
            if (courseName == null)
            {
                return NotFound();
            }
            return View(courseName);
        }

        // POST: CourseNames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Admin, Editor")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CourseName courseName)
        {
            if (id != courseName.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseNameExists(courseName.Id))
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
            return View(courseName);
        }

        // GET: CourseNames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CourseName == null)
            {
                return NotFound();
            }

            var courseName = await _context.CourseName
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseName == null)
            {
                return NotFound();
            }

            return View(courseName);
        }

        // POST: CourseNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Editor")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CourseName == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CourseName'  is null.");
            }
            var courseName = await _context.CourseName.FindAsync(id);
            if (courseName != null)
            {
                _context.CourseName.Remove(courseName);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseNameExists(int id)
        {
            return _context.CourseName.Any(e => e.Id == id);
        }
    }
}
