using Class04.Database;
using Class04.Models.DtoModel;
using Class04.Models.Entites;
using Class04.Models.ViewModels;

namespace Class04.Services
{
    public class CourseService
    {
        public List<CourseDto> GetAllCourses()
        {
            List<CourseDto> courses = InMemoryDb.Courses.Select(x => new CourseDto(x.Id, x.Name, x.NumberOfClasses)).ToList();
            return courses;
        }
        public CourseDto GetCourseById(int id)
        {
            Course course = InMemoryDb.Courses.SingleOrDefault(x => x.Id == id);
            if (course == null) { return null; }
            return new CourseDto(course.Id, course.Name, course.NumberOfClasses);
        }


        internal void CreateCourse(CreateCourseVM viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.Name))
            {
                throw new ArgumentException("Course name cannot be null or empty.", nameof(viewModel.Name));
            }

            Course entity = new Course
            {
                Id = InMemoryDb.Courses.Count + 1,
                Name = viewModel.Name,
                NumberOfClasses = viewModel.NumberOfCourses
            };
            InMemoryDb.Courses.Add(entity);
        }
    }
}
