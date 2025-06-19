using Class_04_View.Service;
using Microsoft.AspNetCore.Mvc;
using Class_04_View.Models.DtoModel;
using Class_04_View.Models.ViewModels;

namespace Class_04_View.Controllers
{
    [Route("[Controller]")]
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;
        
        public StudentController()
        {
            _studentService = new StudentService();
        }
         
        public IActionResult GetAllStudents()
        {
            List<StudentWithCourseDto> students = _studentService.getAllStudents();

            return View(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            StudentWithCourseDto student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                return View(student);
            }
        }
        [HttpGet("CreateStudent")]
        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost("CreateStudent")]
        public IActionResult CreateStudent(
            CreateStudentVM createStudentVM)
        {
            _studentService.CreateStudent
                (createStudentVM);
            return RedirectToAction("GetAllStudents");
        }
    }
}
