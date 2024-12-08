using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using sacafoldinh1.Data;
using Microsoft.AspNetCore.Authorization;
using sacafoldinh1.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Net.Mail;

namespace sacafoldinh1.Controllers
{

    public class CreateCourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CreateCourseController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Courses
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var enrollments = _context.Enrollments.Include(e => e.Course).Include(e => e.User)
            //    .Where(e => e.UserId == userId).
            //    ToList();
            //return View(enrollments);

            var courses = _context.Courses.Include(c => c.CreatedBy)
                .Where(e => e.CreatedById == userId).
                ToList();
            return View(courses); 
           
        }
        


        // GET: Courses/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await _context.Courses
                .Include(c => c.CreatedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
        // GET: Courses/Create




        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCourseView model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // الحصول على معرّف المستخدم الحالي

                // إنشاء كيان الدورة التدريبية
                var course = new Course
                {

                    Title = model.Title,
                    Description = model.Description,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    CreatedById = userId // ربط الدورة بالمستخدم الحالي
                };

                // حفظ الدورة في قاعدة البيانات
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index"); // توجيه المستخدم بعد الحفظ
            }

            return View(model); // إعادة عرض الصفحة في حالة وجود أخطاء
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,StartDate,EndDate,CreatedById")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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
            ViewData["CreatedById"] = new SelectList(_context.Users, "Id", "Id", course.CreatedById);
            return View(course);
        }

        // GET: Courses/Delete/5
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.CreatedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [Authorize(Roles = "Teacher")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }

        public IActionResult CourseDetails (int courseId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);    
            var course = _context.Courses.Include(c=>c.Modules).ThenInclude(u=>u.Lessons)
                .Include(c=>c.Exams).Include(c=>c.Assignments).FirstOrDefault(c=>c.Id == courseId);
                
                return View(course);
        }

    }
}
