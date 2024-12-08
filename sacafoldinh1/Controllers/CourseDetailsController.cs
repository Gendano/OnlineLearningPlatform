using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sacafoldinh1.Data;
using sacafoldinh1.Models;
using static sacafoldinh1.Models.CourseDetailsViewModel;

namespace sacafoldinh1.Controllers
{
    public class CourseDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CourseDetailsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult CourseDetails(int courseId)
        {
            var  course = _context.Courses.Include(c=>c.Modules)
                .ThenInclude(c=>c.Lessons).Include(c=>c.Assignments)
                .Include(c=>c.Exams).FirstOrDefault(c=>c.Id == courseId);
            if (course == null) { return NotFound(); }

            var viewModel = new CourseDetailsViewModel
            {
                CourseId = course.Id,
                CourseTitle = course.Title,
                CourseDescription = course.Description,
                Modules = course.Modules.Select(m=> new ModuleViewModel { 
                    ModuleId = m.Id,
                    ModuleTitle = m.Title,
                    Lessons = m.Lessons.Select( I => new LessonViewModel
                    {
                        LessonId = I.Id,
                        LessonTitle = I.Title,
                    }).ToList(),
                    }).ToList(),
                    Exams = course.Exams.Select(t => new ExamViewModel
                    {
                        ExamId = t.Id,
                        ExamTitle = t.Title,
                    }).ToList(),
                    Assignments = course.Assignments.Select(a=> new AssignmentViewModel
                    {
                        AssignmentId = a.Id,
                        AssignmentTitle = a.Title,

                    }).ToList()
               
            };


            return View(viewModel);
        }
    }
}
