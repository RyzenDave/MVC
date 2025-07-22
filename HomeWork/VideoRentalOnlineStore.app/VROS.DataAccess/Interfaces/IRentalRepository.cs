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
    Task<IEnumerable<Rental>> GetActiveRentalsForUserAsync(int userId);
    Task<Rental> GetRentalDetailsAsync(int rentalId);
    Task RentMovieAsync(int userId, int movieId);
    Task ReturnMovieAsync(int rentalId);
  }
}
