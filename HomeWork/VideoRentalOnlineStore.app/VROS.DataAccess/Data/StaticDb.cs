using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VROS.Domain;
using VROS.Domain.Enums;

namespace VROS.DataAccess.Data
{
    public static class StaticDb
    {
        public static List<Cast> Cast { get; set; }
        public static List<Movie> Movies { get; set; }
        public static List<Rental> Rentals { get; set; }
        public static List<User> Users { get; set; }

        // Replace LoadCustomers() with LoadUsers() in the static constructor
        static StaticDb()
        {
            LoadMovies();
            LoadCast();
            LoadUsers();
            LoadRentals();
        }

        private static void LoadUsers()
        {
            Users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FullName = "Alice Johnson",
                    Age = 28,
                    CardNumber = "1234567890",
                    CreatedOn = DateTime.Today.AddYears(-2),
                    IsSubscriptionExpired = false,
                    SubscriptionType = SubscriptionType.Monthly,
                    Roles = UserRoles.Admin
                },
                new User
                {
                    Id = 2,
                    FullName = "Bob Smith",
                    Age = 35,
                    CardNumber = "2345678901",
                    CreatedOn = DateTime.Today.AddYears(-1),
                    IsSubscriptionExpired = false,
                    SubscriptionType = SubscriptionType.Yearly,
                    Roles = UserRoles.User
                },
                new User
                {
                    Id = 3,
                    FullName = "Charlie Brown",
                    Age = 22,
                    CardNumber = "3456789012",
                    CreatedOn = DateTime.Today.AddMonths(-6),
                    IsSubscriptionExpired = true,
                    SubscriptionType = SubscriptionType.Free,
                    Roles = UserRoles.User
                },
                new User
                {
                    Id = 4,
                    FullName = "Diana Prince",
                    Age = 30,
                    CardNumber = "4567890123",
                    CreatedOn = DateTime.Today.AddYears(-3),
                    IsSubscriptionExpired = false,
                    SubscriptionType = SubscriptionType.Lifetime,
                    Roles = UserRoles.User
                },
                new User
                {
                    Id = 5,
                    FullName = "Ethan Hunt",
                    Age = 40,
                    CardNumber = "5678901234",
                    CreatedOn = DateTime.Today.AddMonths(-2),
                    IsSubscriptionExpired = true,
                    SubscriptionType = SubscriptionType.Monthly,
                    Roles = UserRoles.User
                }
            };
        }


        private static void LoadCast()
        {
            Cast = new List<Cast>
            {
                new Cast { Id = 1, MovieId = 1, Name = "John Smith", Part = MoviePart.Actor },
                new Cast { Id = 2, MovieId = 2, Name = "Jane Doe", Part = MoviePart.Director },
                new Cast { Id = 3, MovieId = 2, Name = "Alice Brown", Part = MoviePart.Actor },
                new Cast { Id = 4, MovieId = 3, Name = "Bob White", Part = MoviePart.Camera },
                new Cast { Id = 5, MovieId = 4, Name = "Eve Black", Part = MoviePart.Sound }
            };
        }

        private static void LoadMovies()
        {
            Movies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title = "The First Movie",
                    Genre = Genre.Action,
                    Language = Language.English,
                    IsAvailable = true,
                    ReleaseDate = new DateTime(2020, 1, 1),
                    Length = TimeSpan.FromMinutes(120),
                    AgeRestriction = 16,
                    Quantity = 5
                },
                new Movie
                {
                    Id = 2,
                    Title = "Second Chance",
                    Genre = Genre.Drama,
                    Language = Language.English,
                    IsAvailable = true,
                    ReleaseDate = new DateTime(2021, 5, 10),
                    Length = TimeSpan.FromMinutes(110),
                    AgeRestriction = 12,
                    Quantity = 3
                },
                new Movie
                {
                    Id = 3,
                    Title = "Comedy Night",
                    Genre = Genre.Comedy,
                    Language = Language.English,
                    IsAvailable = true,
                    ReleaseDate = new DateTime(2019, 8, 20),
                    Length = TimeSpan.FromMinutes(95),
                    AgeRestriction = 10,
                    Quantity = 4
                },
                new Movie
                {
                    Id = 4,
                    Title = "Horror House",
                    Genre = Genre.Horror,
                    Language = Language.English,
                    IsAvailable = false,
                    ReleaseDate = new DateTime(2022, 10, 31),
                    Length = TimeSpan.FromMinutes(100),
                    AgeRestriction = 18,
                    Quantity = 2
                },
                new Movie
                {
                    Id = 5,
                    Title = "Sci-Fi World",
                    Genre = Genre.SciFi,
                    Language = Language.English,
                    IsAvailable = true,
                    ReleaseDate = new DateTime(2023, 3, 15),
                    Length = TimeSpan.FromMinutes(130),
                    AgeRestriction = 14,
                    Quantity = 6
                }
            };
        }

    
            
        private static void LoadRentals()
        {
            Rentals = new List<Rental>
            {
                new Rental
                {
                    Id = 1,
                    MovieId = 1,
                    UserId = 1,
                    RentedOn = DateTime.Today.AddDays(-10),
                    ReturnedOn = DateTime.Today.AddDays(-5)
                },
                new Rental
                {
                    Id = 2,
                    MovieId = 2,
                    UserId = 2,
                    RentedOn = DateTime.Today.AddDays(-8),
                    ReturnedOn = DateTime.Today.AddDays(-3)
                },
                new Rental
                {
                    Id = 3,
                    MovieId = 3,
                    UserId = 3,
                    RentedOn = DateTime.Today.AddDays(-6),
                    ReturnedOn = DateTime.Today.AddDays(-1)
                },
                new Rental
                {
                    Id = 4,
                    MovieId = 4,
                    UserId = 4,
                    RentedOn = DateTime.Today.AddDays(-4),
                    ReturnedOn = default
                },
                new Rental
                {
                    Id = 5,
                    MovieId = 5,
                    UserId = 5,
                    RentedOn = DateTime.Today.AddDays(-2),
                    ReturnedOn = default
                }
            };
        }
    }
}
