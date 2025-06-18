using MVC_model_class.Database;
using MVC_model_class.Models.DtoModels;
using MVC_model_class.Models.Entities;

namespace MVC_model_class.Services
{
    public class CourseService
    {
            public List<CourseDto> GetAllCourses()
        {
            return InMemoryDb.Courses.Select(course => new CourseDto
            {
                Name = course.Name
            }).ToList() ?? new List<CourseDto>();
        }
        
        public AllCourseInfoDto GetAllCourseInfo(int id)
        {
            var courses = InMemoryDb.Courses;
            if (courses == null)
            {
                return new AllCourseInfoDto
                {
                    Id = 0,
                    Name = string.Empty,
                    NumOfClasses = 0
                };
            }
            
            var course = courses.SingleOrDefault(course => course.Id == id);
            if (course == null)
            {
                return new AllCourseInfoDto
                {
                    Id = 0,
                    Name = string.Empty,
                    NumOfClasses = 0
                };
            }
            
            AllCourseInfoDto allCourseInfo = new AllCourseInfoDto()
            {
                Id = id,
                NumOfClasses = course.NumOfClasses,
                Name = course.Name
            };
            return allCourseInfo;
        }
    }
}
