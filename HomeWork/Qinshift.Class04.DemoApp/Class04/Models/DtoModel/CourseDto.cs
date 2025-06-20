namespace Class04.Models.DtoModel
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfClasses { get; set; }

        public CourseDto(int id, string name, int numberOfClasses)
        {
            Id = id;
            Name = name;
            NumberOfClasses = numberOfClasses;  
        }
    }
}
