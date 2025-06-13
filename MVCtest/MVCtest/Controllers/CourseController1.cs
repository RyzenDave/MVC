using Microsoft.AspNetCore.Mvc;
using MVCtest.Models;

namespace MVCtest.Controllers
{
    public class CourseController : Controller
    {
        //Conventional routing

        private List<Course> _courses = new List<Course>
        {
            new Course { Id = 1,
                Name = "basic C#", 
                NumberOfClasses = 10 },
            new Course { Id = 2, 
                Name = "Adv C#", 
                NumberOfClasses = 15 },
            new Course { Id = 3,
                Name = "ASP.NET CORE MVC",
                NumberOfClasses = 10 },
            new Course { Id = 4,
                Name = "ASP.NET CORE WEB API",
                NumberOfClasses = 15 }
        };
        public JsonResult GetAllCourses()
        {
            return Json(_courses);
        }
        public IActionResult GetAllCourses1()
        {
            return Json(_courses);
        }
        public IActionResult GetCourseById(int id)
        {
            return Json(_courses.SingleOrDefault(x=>x.Id == id));
        }
        public IActionResult GetCourseByIdOrName(int id, string name)
        {
            Course course = _courses.FirstOrDefault(x => x.Id == id);

            if(course == null)
            {
                course = _courses.FirstOrDefault(x => x.Name == name);
                if (course == null) return NoContent();
                return Json(course);
            }
            else
            {
                return Json(course);
            }
        }       
    }
}
