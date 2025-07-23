using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VROS.DataAccess.Interfaces;
using VROS.Domain;

namespace VROS.DataAccess.Repository
{
    internal class MovieRepository : IMovieRepository
    {
        private readonly List<Movie> _movies = new();

        public Task AddAsync(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            // Simulate auto-increment Id
            movie.Id = _movies.Count > 0 ? _movies.Max(m => m.Id) + 1 : 1;
            _movies.Add(movie);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                _movies.Remove(movie);
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Movie>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Movie>>(_movies.ToList());
        }

        public Task<Movie> GetByIdAsync(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            return Task.FromResult(movie);
        }

        public Task UpdateAsync(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            var existing = _movies.FirstOrDefault(m => m.Id == movie.Id);
            if (existing != null)
            {
                existing.Title = movie.Title;
                existing.Genre = movie.Genre;
                existing.Language = movie.Language;
                existing.IsAvailable = movie.IsAvailable;
                existing.ReleaseDate = movie.ReleaseDate;
                existing.Length = movie.Length;
                existing.AgeRestriction = movie.AgeRestriction;
                existing.Quantity = movie.Quantity;
            }
            return Task.CompletedTask;
        }
    }
}
