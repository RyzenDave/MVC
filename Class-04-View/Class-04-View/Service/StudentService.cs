using Class_04_View.DataBase;
using Class_04_View.Models.DtoModel;
using Class_04_View.Models.Entities;
using Class_04_View.Models.ViewModels;

namespace Class_04_View.Service
{
    public class StudentService
    {
        public List<StudentWithCourseDto> getAllStudents()
        {
            List<StudentWithCourseDto> students = InMemoryDb.Students.Select(x => new StudentWithCourseDto
            (x.Id, x.FirstName, x.LastName, x.DateOfBirth, x.ActiveCourse.Name)).ToList();
            return students;
        }
        public StudentWithCourseDto GetStudentById(int id)
        {
            var student = InMemoryDb.Students
                .FirstOrDefault(x => x.Id == id);

            if (student == null)
            {
                return null; // or throw new NotFoundException("Student not found");
            }

            return new StudentWithCourseDto(
                student.Id,
                student.FirstName,
                student.LastName,
                student.DateOfBirth,
                student.ActiveCourse?.Name); // null-conditional operator for safety
        }
        public void CreateStudent(CreateStudentVM 
            viewModel)
        {
            Student entity = new Student
            {
                Id = InMemoryDb.Students.Count + 1,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                DateOfBirth = viewModel.DateOfBirth,
                ActiveCourse = InMemoryDb.Courses[2]
            };
        }
    }
}
