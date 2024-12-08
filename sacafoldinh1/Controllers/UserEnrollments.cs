using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sacafoldinh1.Data;
using sacafoldinh1.Models;
using System.Security.Claims;

namespace sacafoldinh1.Controllers
{
    public class UserEnrollments : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserEnrollments(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var enrollments = _context.Enrollments.Include(e => e.Course).Include(e => e.User)
                .Where(e => e.UserId == userId).
                ToList();
            return View(enrollments);
        
        }
    }
}
