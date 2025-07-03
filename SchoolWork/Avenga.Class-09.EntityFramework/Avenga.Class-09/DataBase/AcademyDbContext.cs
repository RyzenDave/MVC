using Avenga.Class_09.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Avenga.Class_09.DataBase
{
    public class AcademyDbContext : DbContext
    {
        //First create a ctor with the needed Db context options 
        //passed to its parent ctor
        public AcademyDbContext(DbContextOptions options) : base(options)
        {
                   
        }
        //Second configure which models will be translated as tables in the DB
        public DbSet <Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        // Thrid Override the onmodelcreating method so that you will configure the relations,
        // the data that needs
        // to be seeded upfront and also the rules for some
        // of the properties of the domain models
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Courses
            List<Course> courses = new List<Course>
            {
                new Course {
                    Id = 1,
                    Name = "C# Basic",
                    NumberOfClasses = 30 },
                new Course { 
                    Id = 2, 
                    Name = "C# Advanced", 
                    NumberOfClasses = 25 },
                new Course { 
                    Id = 3, 
                    Name = "ASP.net", 
                    NumberOfClasses = 20 }
            };

            // Seed Students
             List<Student> students = new List<Student>
            {
                new Student { 
                    Id = 1, 
                    FirstName = "Alice", 
                    LastName = "Smith",
                    DateOfBirth = new DateTime(2000, 1, 15), 
                    ActiveCourseId = 1 },
                new Student {
                    Id = 2,
                    FirstName = "Bob", 
                    LastName = "Johnson", 
                    DateOfBirth = new DateTime(2001, 5, 23),
                    ActiveCourseId = 2 },
                new Student { Id = 3,
                    FirstName = "Charlie",
                    LastName = "Brown", 
                    DateOfBirth = new DateTime(1999, 11, 2), 
                    ActiveCourseId = 3 }
            };

            

            modelBuilder.Entity<Course>().HasData(courses);
            modelBuilder.Entity<Student>().HasData(students);
        }
    }
}
