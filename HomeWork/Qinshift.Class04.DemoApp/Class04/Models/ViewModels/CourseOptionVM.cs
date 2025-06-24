namespace Class04.Models.ViewModels
{
    public class CourseOptionVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? ActiveCourseId { get; set; }
        public List<CourseOptionVM> Courses { get; set; }

    }
}
