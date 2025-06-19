using Class_04_View.Models.Entities;

namespace Class_04_View.Models.DtoModel
{
    public class StudentWithCourseDto
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }
        public string NameOfCourse { get; set; }
        public StudentWithCourseDto(int id, string fname, string 
            lname,DateTime dateOfBirth, string coursename )
        {
            Id = id;
            FullName = $"{fname} {lname}";
            NameOfCourse = coursename;
            Age = DateTime.Now.Year - dateOfBirth.Year;
        }
    }
}
