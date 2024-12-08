using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sacafoldinh1.Data;
using sacafoldinh1.Models;
using System.Security.Claims;

namespace sacafoldinh1.Controllers
{
    public class ExamsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ExamsController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult Create(int courseId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var course = _context.Courses.FirstOrDefault(c => c.Id == courseId && c.CreatedById == userId);
            if (course == null)
            {
                return NotFound();
            }
            var model = new ExamCreateViewModel { CourseId = courseId };
            return View(course);
        }

        [HttpPost]
        public IActionResult Create(ExamCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var exam = new Exam
                {
                    Title = model.Title,
                    Date = model.CreatedDate,
                    CourseId = model.CourseId,
                };
                foreach (var quetionVm in model.Questions)
                {
                    var question = new Question
                    {
                        Text = quetionVm.Text,
                        Score = quetionVm.Score,
                        Exam = exam
                    };
                    foreach (var anserVm in question.Answers)
                    {
                        question.Answers.Add(new Answer
                        {
                            Text = anserVm.Text,
                            IsCorrect = anserVm.IsCorrect
                        });
                    }
                    exam.Questions.Add(question);
                }
                _context.Exams.Add(exam);
                _context.SaveChanges();
                return RedirectToAction("Details", "Courses", new { id = model.CourseId });
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult ExamDetails(int id)
        {
            var exam = _context.Exams.Include(e => e.Questions).ThenInclude(e => e.Answers).FirstOrDefault(e => e.Id == id);

            if (exam == null)
            {
                return NotFound();
            }
            return View(exam);
        }
    } 
}
