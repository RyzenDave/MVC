using Avenga.Class_09.DataBase;
using Avenga.Class_09.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Avenga.Class_09.Controllers
{
    public class StudentController : Controller
    {
        private readonly AcademyDbContext _context;
        public StudentController(AcademyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students
                                   .Include(s => s.ActiveCourse)
                                   .ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
    }
}
