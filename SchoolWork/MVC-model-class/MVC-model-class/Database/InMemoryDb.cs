using MVC_model_class.Models.Entities;

namespace MVC_model_class.Database
{
    public class InMemoryDb
    {
        public static List<Student> Students {  get; set; }
        public static List<Course> Courses { get; set; }

        private static void LoadStudents()
        {
            Students = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-20), // 20 years old
                    ActiveCourse = Courses[0] // First course
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Jill",
                    LastName = "Smith",
                    DateOfBirth = DateTime.Now.AddYears(-19), // 19 years old
                    ActiveCourse = Courses[1] // Second course
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Jack",
                    LastName = "Johnson",
                    DateOfBirth = DateTime.Now.AddYears(-21), // 21 years old
                    ActiveCourse = Courses[2] // Third course
                }
            };
        }
            private static void LoadCourses()
        {
            Courses = new List<Course>()
    {
        new Course()
        {
            Id = 1,
            Name = "Introduction to Programming",
            NumOfClasses = 20
        },
        new Course()
        {
            Id = 2,
            Name = "Web Development Fundamentals",
            NumOfClasses = 15
        },
        new Course()
        {
            Id = 3,
            Name = "Database Design",
            NumOfClasses = 12
        }
            };
        }
    }
}
