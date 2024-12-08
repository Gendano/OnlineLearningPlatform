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

namespace sacafoldinh1.Controllers
{

    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CoursesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Courses
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.Courses.Include(c => c.CreatedBy);
            return View(await applicationDbContext.ToListAsync());
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




        public IActionResult Create()
        {


            ViewData["CreatedById"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("Id,Title,Description,StartDate,EndDate,CreatedById")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedById"] = new SelectList(_context.Users, "Id", "Id", course.CreatedById);
            return View(course);
        }

        // GET: Courses/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["CreatedById"] = new SelectList(_context.Users, "Id", "Id", course.CreatedById);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

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


        public IActionResult CourseDetails(int courseId)
        {

            var course = _context.Courses.Include(c => c.Modules).ThenInclude(u => u.Lessons)
                .Include(c => c.Exams).Include(c => c.Assignments).FirstOrDefault(c => c.Id == courseId);

            return View(course);
        }

        [HttpPost]

        public IActionResult CreateLesson(int courseId, string lessonTitle
            , string lessonDetails, IFormFile lessonVideo, int? moduleId, string newModuleTitle ,string newMduleDescription)
        {


            if (!IsCourseOwner(courseId))
            {
                return Unauthorized();
            }
            Module module;
            if (!string.IsNullOrEmpty(newModuleTitle))
            {
                module = new Module
                {
                    Title = newModuleTitle,
                    Description = newMduleDescription,
                    CourseId = courseId,
                    

                };

                _context.Modules.Add(module);
                _context.SaveChanges();
            }
            else if (moduleId.HasValue)
            {
                module = _context.Modules.FirstOrDefault(m => m.Id == moduleId);
                if (module == null)
                {
                    return BadRequest();
                }

            }
            else
            {
                return BadRequest();
            }


            var videoPath = Path.Combine("wwwroot/videos", lessonVideo.FileName);
            using (var stream = new FileStream(videoPath, FileMode.Create))
            {
                lessonVideo.CopyTo(stream);
            }
            var lesson = new Lesson
            {
                Title = lessonTitle,
                Description = lessonDetails,
                VideoPath = "/videos/" + lessonVideo.FileName,
                ModuleId = module.Id,
            };
            _context.Lessons.Add(lesson);
            _context.SaveChanges();

            return RedirectToAction("CourseDetails", "Courses", new { courseId = courseId });

        }


        private bool IsCourseOwner(int courseId)

        {
            var instructorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return _context.Courses.Any(c => c.Id == courseId && c.CreatedById == instructorId);
        }

        [HttpPost]
        public IActionResult CreateExam(int courseId, string ExamTitle, string ExamDescription)
        {
            if (!IsCourseOwner(courseId))
            {
                return Unauthorized();
            }

            var exam = new Exam
            {
                Title = ExamTitle,
               CourseId = courseId,

            };
            _context.Exams.Add(exam);
            _context.SaveChanges();

            return RedirectToAction("CourseDetails","Courses", new { courseId = courseId});

        }



        [HttpPost]
        public IActionResult CreateAssignment(int courseId, string AssignmentTitle, string AssignmentDescription , DateTime dueDate)
        {
            if (!IsCourseOwner(courseId))
            {
                return Unauthorized();
            }

            var assignment = new Assignment
            {
                Title = AssignmentTitle,
                Description = AssignmentDescription,
                CourseId = courseId,

                DueDate  = dueDate,

            };
            _context.Assignments.Add(assignment);
            _context.SaveChanges();

            return RedirectToAction("CourseDetails", "Courses", new { courseId = courseId });

        }
        [HttpGet]
        public async Task<IActionResult> MyLessons()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var lessons = await _context.Lessons.Include(i => i.Module)
                .Where(i => i.Module.Course.CreatedById == userId)
                .Select(i => new ShowLessonsViewModel
                {
                    Id = i.Id,
                    Title = i.Title,
                    Description = i.Description,
                    VideoPath = i.VideoPath,
                    ModuleTitle = i.Module.Title,
                    CourseTitle = i.Module.Course.Title
                }).ToListAsync();

            return View(lessons);
        }

        public IActionResult LessonDetails(int courseId , int moduleId , int lessonId)
        {
            var lesson = _context.Lessons.Include(i => i.Module)
                    .ThenInclude(i => i.Course)
                    .FirstOrDefault(i => i.Id == lessonId && i.ModuleId == moduleId && i.Module.Course.Id == courseId);
                

            if (lesson == null)
            {
                return NotFound();
            }
            var viewModel = new LessonDetailsViewModel
            {
                Id = lesson.Id,
                Title = lesson.Title,
                Description = lesson.Description,
                VideoPath = lesson.VideoPath,
            };

        return View(lesson);
        }

        [HttpGet]
        public IActionResult CreateExam(int courseId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var course = _context.Courses.FirstOrDefault(c => c.Id == courseId && c.CreatedById == userId);
            if (course == null)
            {
                return NotFound();
            }
            var model = new ExamCreateViewModel { CourseId = courseId };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateExam(ExamCreateViewModel model)
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
