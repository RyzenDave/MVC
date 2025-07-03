using Class_07_model_binding.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Class_07_model_binding.Models.Entities;
using System.ComponentModel;

namespace Class_07_model_binding.Controllers
{
    public class StudentController : Controller
    {
        // In-memory database of students
        private static readonly List<StudentDto> Students = new()
            {
                new StudentDto { FirstName = "Alice", LastName = "Smith", Age = 20, DateOfBirth = new DateTime(2004, 1, 15) },
                new StudentDto { FirstName = "Bob", LastName = "Johnson", Age = 22, DateOfBirth = new DateTime(2002, 5, 23) },
                new StudentDto { FirstName = "Charlie", LastName = "Williams", Age = 19, DateOfBirth = new DateTime(2005, 3, 10) },
                new StudentDto { FirstName = "Diana", LastName = "Brown", Age = 21, DateOfBirth = new DateTime(2003, 7, 8) }
            };

        [HttpGet]
        public IActionResult Index()
        {
            return View(Students);
        }
    }
}
