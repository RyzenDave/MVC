using Microsoft.AspNetCore.Mvc;
using MVC_model_class.Models.DtoModels;
using MVC_model_class.Services;

namespace MVC_model_class.Controllers
{
    [Route("Students")]
    public class StudentController : Controller
    {
        private StudentService _studenService;
        public StudentController()
        {
            _studenService = new StudentService();
        }
        public IActionResult GetStudentById (int id)
        {
            StudentWithCourseDto student = 
                _studenService.GetStudentWithCourse(id);
            if(student == null)
            {
                return Content("Student not found");
            }
            else
            {
                return Json(student);
            }
        }
    }
}
