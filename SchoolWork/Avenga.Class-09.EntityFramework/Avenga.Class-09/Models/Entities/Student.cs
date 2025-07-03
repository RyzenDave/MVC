using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avenga.Class_09.Models.Entities
{
    public class Student
    {
       
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ActiveCourseId { get; set; }
        public Course ActiveCourse { get; set; }
    }
}
