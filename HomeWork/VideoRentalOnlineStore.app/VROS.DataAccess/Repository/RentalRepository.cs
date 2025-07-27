using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VROS.DataAccess.Interfaces;
using VROS.Domain;

namespace VROS.DataAccess.Repository
{
    public class RentalRepository : IUserRentalRepository
    {
        public Task AddAsync(Rental rental)
        {
            rental.Id = StaticDb.Rentals.Count + 1;
            StaticDb.Rentals.Add(rental);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var rental = StaticDb.Rentals.FirstOrDefault(r => r.Id == id);
            if (rental != null)
            {
                StaticDb.Rentals.Remove(rental);
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Rental>> GetActiveRentalsForUserAsync(int userId)
        {
            var now = DateTime.UtcNow;
            var activeRentals = StaticDb.Rentals
                .Where(r => r.UserId == userId && (r.ReturnedOn == default || r.ReturnedOn > now))
                .ToList();
            return Task.FromResult<IEnumerable<Rental>>(activeRentals);
        }

        public Task<IEnumerable<Rental>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Rental>>(StaticDb.Rentals.ToList());
        }

        public Task<Rental?> GetByIdAsync(int id)
        {
            var rental = StaticDb.Rentals.FirstOrDefault(r => r.Id == id);
            return Task.FromResult<Rental?>(rental);
        }

        public Task<Rental> GetRentalDetailsAsync(int rentalId)
        {
            var rental = StaticDb.Rentals.FirstOrDefault(r => r.Id == rentalId);
            if (rental == null)
                throw new KeyNotFoundException($"Rental with ID {rentalId} not found.");
            return Task.FromResult(rental);
        }

        public Task RentMovieAsync(int userId, int movieId)
        {
            var rental = new Rental
            {
                Id = StaticDb.Rentals.Count + 1,
                UserId = userId,
                MovieId = movieId,
                RentedOn = DateTime.UtcNow,
                ReturnedOn = default
            };
            StaticDb.Rentals.Add(rental);
            return Task.CompletedTask;
        }

        public Task ReturnMovieAsync(int rentalId)
        {
            var rental = StaticDb.Rentals.FirstOrDefault(r => r.Id == rentalId);
            if (rental != null)
            {
                rental.ReturnedOn = DateTime.UtcNow;
            }
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Rental entity)
        {
            var rental = StaticDb.Rentals.FirstOrDefault(r => r.Id == entity.Id);
            if (rental != null)
            {
                rental.MovieId = entity.MovieId;
                rental.UserId = entity.UserId;
                rental.RentedOn = entity.RentedOn;
                rental.ReturnedOn = entity.ReturnedOn;
            }
            return Task.CompletedTask;
        }
    }
}
