using Microsoft.AspNetCore.Mvc;
using MVC_model_class.Models.DtoModels;
using MVC_model_class.Services;

namespace MVC_model_class.Controllers
{
    [Route("Course")]
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;

        public CourseController()
        {
            _courseService = new CourseService();
        }

        // 3.1: Returns a list of all course names as JSON
        [HttpGet("Names")]
        public IActionResult GetAllCourseNames()
        {
            var courses = _courseService.GetAllCourses();
            var courseNames = courses.Select(c => c.Name).ToList();
            return Json(courseNames);
        }

        // 3.2: Returns the full course object as JSON by id
        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            var course = _courseService.GetAllCourseInfo(id);
            if (course == null)
            {
                return NotFound();
            }
            return Json(course);
        }
    }
}
