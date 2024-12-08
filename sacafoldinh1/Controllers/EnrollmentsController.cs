using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using sacafoldinh1.Data;
using Microsoft.AspNetCore.Identity;
using sacafoldinh1.Models;

namespace sacafoldinh1.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
       
        public EnrollmentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

      

            // GET: Enrollments
            public async Task<IActionResult> Index()
            {
                var applicationDbContext = _context.Enrollments.Include(e => e.Course).Include(e => e.User);
                return View(await applicationDbContext.ToListAsync());
            }

            // GET: Enrollments/Details/5
            public async Task<IActionResult> Details(string UserId, int CourseId)
            {
                if (UserId == null || CourseId == null)
                {
                    return NotFound();
                }

                var enrollment = await _context.Enrollments
                    .Include(e => e.Course)
                    .Include(e => e.User)
                    .FirstOrDefaultAsync(m => m.UserId == UserId && m.CourseId == CourseId);

                if (enrollment == null)
                {
                    return NotFound();
                }

                return View(enrollment);
            }

            // GET: Enrollments/Create
            public IActionResult Create()
            {
                ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "Title");
                ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Name");
                return View();
            }

            // POST: Enrollments/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("UserId,CourseId,EnrollmentDate,Progress,CompletionDate")] Enrollment enrollment)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(enrollment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", enrollment.CourseId);
                ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", enrollment.UserId);
                return View(enrollment);
            }

            // GET: Enrollments/Edit/5
            public async Task<IActionResult> Edit(string UserId, int CourseId)
            {

                var enrollment = await _context.Enrollments.FindAsync(UserId, CourseId);

                if (enrollment == null)
                {
                    return NotFound();
                }
                ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", enrollment.CourseId);
                ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", enrollment.UserId);
                return View(enrollment);
            }

            // POST: Enrollments/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(string UserId, int CourseId, [Bind("UserId,CourseId,EnrollmentDate,Progress,CompletionDate")] Enrollment enrollment)
            {
                if (UserId != enrollment.UserId || CourseId != enrollment.CourseId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(enrollment);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EnrollmentExists(enrollment.UserId))
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
                ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", enrollment.CourseId);
                ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", enrollment.UserId);
                return View(enrollment);
            }

            // GET: Enrollments/Delete/5
            public async Task<IActionResult> Delete(string UserId, int CourseId)
            {
                if (UserId == null || CourseId == null)
                {
                    return NotFound();
                }

                var enrollment = await _context.Enrollments
                    .Include(e => e.Course)
                    .Include(e => e.User)
                    .FirstOrDefaultAsync(m => m.UserId == UserId && m.CourseId == CourseId);
                if (enrollment == null)
                {
                    return NotFound();
                }

                return View(enrollment);
            }

            // POST: Enrollments/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(string UserId, int CourseId)
            {
                var enrollment =  _context.Enrollments.Find(UserId, CourseId);
                if (enrollment != null)
                {
                    _context.Enrollments.Remove(enrollment);
                }

                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool EnrollmentExists(string id)
            {
                return _context.Enrollments.Any(e => e.UserId == id);
            }
        }
    }
