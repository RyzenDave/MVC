using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VROS.Domain;

namespace VROS.DataAccess.Interfaces
{
    public interface IUserRentalRepository
    {
        // Returns all active rentals for a given user (where ReturnedOn is null or in the future)
        Task<IEnumerable<Rental>> GetActiveRentalsForUserAsync(int userId);

        // Returns details for a specific rental by its ID
        Task<Rental> GetRentalDetailsAsync(int rentalId);

        // Creates a new rental for a user and a movie
        Task RentMovieAsync(int userId, int movieId);

        // Marks a rental as returned (sets ReturnedOn to now)
        Task ReturnMovieAsync(int rentalId);
    }
}
