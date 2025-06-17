using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using MVC_model_class.Database;
using MVC_model_class.Models.DtoModels;

namespace MVC_model_class.Services
{
    public class StudentService
    {
        public StudentWithCourseDto
            GetStudentWithCourse(int id)
        {
            var student = InMemoryDb.Students.SingleOrDefault
                (x => x.Id == id);
            if (student == null)
            {
                return null;
            }
            StudentWithCourseDto studentWithCourse =
                            new StudentWithCourseDto()
                            {
                                Id = student.Id,
                                FullName = $"{student.FirstName}{student.LastName}",
                                NameOfCourse = student.ActiveCourse.Name,
                                Age = DateTime.Now.Year - student.DateOfBirth.Year
                            };
            return studentWithCourse;
        }
        public List<ListAllStudentsDto> 
            GetAllStudents()
        {
            return InMemoryDb.Students.Select(student => new ListAllStudentsDto
            {
                FullName = $"{student.FirstName} {student.FirstName}"
            });
        }
    } 
}
