using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sacafoldinh1.Data;
using sacafoldinh1.Models;

namespace sacafoldinh1.Controllers
{
    public class CreateLessonsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateLessonsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Lessons
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Lessons.Include(l => l.Module);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons
                .Include(l => l.Module)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lessons/Create

        [HttpGet]
        public IActionResult Create(int moduleId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var module = _context.Modules.Include(m => m.Course)
                .FirstOrDefault(m => m.Id == moduleId && m.Course.CreatedById ==userId);
            if (module == null)
            {

            return NotFound("The specified module does not exist or does not belong to current user "); 
            }
            var model = new CreateLessonViewModel
            {
                ModuleId = moduleId
            };

            return View(model);
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLessonViewModel model ,IFormFile videoFile)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var module = _context.Modules.Include(m => m.Course)
                .FirstOrDefault(m => m.Id == model.ModuleId && m.Course.CreatedById ==userId);
            if (module == null )
            {
                return NotFound("The specified module does not exist or does not belong to current user ");
            }

            if (model.VideoFile != null && model.VideoFile.Length > 0)
            {

                var allowedExtentions = new[] { ".mp4", ".mov", ".avi" };
                var exention = Path.GetExtension(videoFile.FileName).ToLower();
                if (!allowedExtentions.Contains(exention))
                {
                    ModelState.AddModelError("VideoFile", "Invalid video format ");
                    return View(model);
                }


                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/videos");
                if (Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }


                var uniqueFileName = $"{Guid.NewGuid()}{exention}";
                var filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await videoFile.CopyToAsync(stream);
                }
                model.VideoPath = $"/videos/{uniqueFileName}";
            }
            var lesson = new Lesson
            {
                ModuleId = model.ModuleId,
                Title = model.Title,
                Description = model.Description,
                VideoPath = model.VideoPath
            };
            _context.Lessons.Add(lesson);
             _context.SaveChangesAsync();
            return RedirectToAction("Details","Modules",new {id = model.ModuleId});
           

        }

        [HttpGet]
        public async Task<IActionResult>MyLessons ()
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
                    ModuleTitle =i.Module.Title,
                    CourseTitle = i.Module.Course.Title
                }).ToListAsync();

            return View(lessons);
        }


        // GET: Lessons/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var lessons = _context.Lessons.Include(i => i.Module)
                .ThenInclude(i => i.Course)
                .FirstOrDefault(i => i.Id == id && i.Module.Course.CreatedById == userId);
                
            if (lessons == null)
                return NotFound();
            var model = new EditLessonViewModel
            {
                Id = lessons.Id,
                Title = lessons.Title,
                Description = lessons.Description,
                VideoPath = lessons.VideoPath,
                ModuleId = lessons.ModuleId

            };


            return View(model);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditLessonViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            // الحصول على معرف المستخدم الحالي
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // البحث عن الدرس مع التحقق من علاقاته بالدورة والوحدة
            var lesson = _context.Lessons
                .Include(l => l.Module)
                .ThenInclude(m => m.Course)
                .FirstOrDefault(l => l.Id == model.Id && l.Module.Course.CreatedById == userId);

            if (lesson == null)
            {
                return NotFound("لا يمكن العثور على الدرس أو أنك لا تملك صلاحية التعديل.");
            }

            // تحديث بيانات الدرس
            lesson.Title = model.Title;
            lesson.Description = model.Description;

            // معالجة الفيديو إذا تم رفع ملف جديد
            if (model.VideoFile != null)
            {
                // حذف الفيديو القديم
                if (!string.IsNullOrEmpty(lesson.VideoPath))
                {
                    var oldVideoPath = Path.Combine(_webHostEnvironment.WebRootPath, "wwwroot/videos", lesson.VideoPath);
                    if (!System.IO.File.Exists(oldVideoPath))
                    {
                        System.IO.File.Delete(oldVideoPath);
                    }
                }

                // رفع الفيديو الجديد
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/videos");
               
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.VideoFile.FileName;

                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.VideoFile.CopyTo(fileStream);
                }

                lesson.VideoPath = uniqueFileName;
            }

            _context.SaveChanges();

            return RedirectToAction("Details", "Modules", new { id = lesson.ModuleId }); // إعادة التوجيه إلى الوحدة
        }


        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons
                .Include(l => l.Module)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson != null)
            {
                _context.Lessons.Remove(lesson);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(int id)
        {
            return _context.Lessons.Any(e => e.Id == id);
        }
    }
}
