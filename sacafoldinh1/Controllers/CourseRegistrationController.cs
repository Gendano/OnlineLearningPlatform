using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sacafoldinh1.Data;
using sacafoldinh1.Models;

namespace sacafoldinh1.Controllers
{
    public class CourseRegistrationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CourseRegistrationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CourseRegistration
        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.Courses.Include(c => c.CreatedBy);
            return View(await applicationDbContext.ToListAsync());

        }

        [HttpPost]
        public async Task<IActionResult> Enroll(int CourseId)
        {
            // عشان نتحصل على المستخدم الحالي
            var userId = _userManager.GetUserId(User);
            var currentUser = _context.Users.Find(userId);
            if (currentUser == null)
            {
                return Unauthorized();
            }
            //  عشان نتحقق اذا كان المستخدم مسجل في الدورة 
            var existingEnrollment = _context.Enrollments
                .FirstOrDefault(e => e.CourseId == CourseId && e.UserId == userId);

            if (existingEnrollment != null)

            {
                TempData["Message"] = "you are already enrolled to this course";
            
            }

            var enrollment = new Enrollment
            {
                CourseId = CourseId,
                UserId = userId,
                EnrollmentDate = DateTime.Now
            };
            _context.Enrollments.Add(enrollment);
           _context.SaveChanges();
         
           
            TempData["Message"] = "enrollment Done";
            return RedirectToAction(nameof(Index));
        }
        // GET: CourseRegistration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _context.Courses
                .Include(c => c.CreatedBy)
                .FirstOrDefault(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
    }
}
