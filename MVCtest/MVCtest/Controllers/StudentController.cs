using Microsoft.AspNetCore.Mvc;
using MVCtest.Models;

namespace MVCtest.Controllers
{
    [Route("Students/[Action]")]
    public class StudentController : Controller
    { 
        List<Student> _students = new List<Student>
        {
            new Student { Id = 1,
                FirstName = "John", 
                LastName = "Doe" },
            new Student { Id = 2, 
                FirstName = "Jane",
                LastName = "Smith" },
            new Student { Id = 3,
                FirstName = "Sam", 
                LastName = "Brown" }
        };
        
        public IActionResult GetAll()
        {
            return Json(_students);
        }
       
        public IActionResult GetStudents()
        {
            return Json(_students); 
        }
         
    }
}
