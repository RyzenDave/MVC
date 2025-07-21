using Avenga.Class_09.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Avenga.Class_09.DataBase
{
    public class AcademyDbContext : DbContext
    {
        public AcademyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                       NumberOfClasses = 20 },
                   new Course {
                       Id = 4,
                       Name = "Entity Framework Core",
                       NumberOfClasses = 18 },
                   new Course {
                       Id = 5,
                       Name = "Azure Fundamentals",
                       NumberOfClasses = 15 }
               };

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
                   new Student {
                       Id = 3,
                       FirstName = "Charlie",
                       LastName = "Brown",
                       DateOfBirth = new DateTime(1999, 11, 2),
                       ActiveCourseId = 3 },
                   new Student {
                       Id = 4,
                       FirstName = "Diana",
                       LastName = "Evans",
                       DateOfBirth = new DateTime(2002, 7, 8),
                       ActiveCourseId = 4 },
                   new Student {
                       Id = 5,
                       FirstName = "Ethan",
                       LastName = "Williams",
                       DateOfBirth = new DateTime(2000, 12, 30),
                       ActiveCourseId = 5 }
               };

            modelBuilder.Entity<Course>().HasData(courses);
            modelBuilder.Entity<Student>().HasData(students);
        }
    }
}
