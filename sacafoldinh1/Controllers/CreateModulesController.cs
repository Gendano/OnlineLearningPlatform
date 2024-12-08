using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sacafoldinh1.Data;
using sacafoldinh1.Models;

namespace sacafoldinh1.Controllers
{
    public class CreateModulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreateModulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CreateModules
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Modules.Include(c => c.Course);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CreateModules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmodule = await _context.Modules
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cmodule == null)
            {
                return NotFound();
            }

            return View(cmodule);
        }

        // GET: CreateModules/Create
        public IActionResult Create(int courseId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var course = _context.Courses.FirstOrDefault(c => c.Id == courseId && c.CreatedById == userId);
            if (course == null)
            {
                return NotFound("Course Not Found");
            }
            var model = new CreateModuleViewModel
            {
                CourseId = courseId,

            };
           
            return View(model);
        }

        // POST: CreateModules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CreateModuleViewModel cmodule)
        {
            if (!ModelState.IsValid)
            {
               
                return View(cmodule);
            }

            var module = new Module
            {
                Title = cmodule.Title,
                CourseId = cmodule.CourseId,
                Description = cmodule.Description,

            };
            _context.Modules.Add(module);
            _context.SaveChanges();
            return RedirectToAction ("Details","Courses",new {id = cmodule.CourseId});
        }

        // GET: CreateModules/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var module = _context.Modules
                .Include(c => c.Course)
                .FirstOrDefault(c => c.Id == id && c.Course.CreatedById == userId);

            if (module == null)
            {
                return NotFound("Module not found or you do not have access to it ");
            }
            var model = new EditModuleViewModel
            {
                Id = module.Id,
                Title = module.Title,
                Description = module.Description
               
            };
            return View(model);
        }

        // POST: CreateModules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditModuleViewModel cmodule)
        {
           

            if (!ModelState.IsValid)
             {    
                    return View(cmodule);
             }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var module = _context.Modules
                .Include(c => c.Course)
                .FirstOrDefault(m => m.Id == cmodule.Id && m.Course.CreatedById == userId);
            if (module == null) {
                return NotFound("Module not found or you do not have access to it ");
            }

            module.Title = cmodule.Title;
            module.Description = cmodule.Description;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: CreateModules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmodule = await _context.Modules
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cmodule == null)
            {
                return NotFound();
            }

            return View(cmodule);
        }

        // POST: CreateModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cmodule = await _context.Modules.FindAsync(id);
            if (cmodule != null)
            {
                _context.Modules.Remove(cmodule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModuleExists(int id)
        {
            return _context.Modules.Any(e => e.Id == id);
        }
    }
}
