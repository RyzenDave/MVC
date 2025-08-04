using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VROS.DataAccess.Interfaces;
using VROS.Domain;
using Microsoft.EntityFrameworkCore;

namespace VROS.DataAccess.EFRepository
{
    public class EFMovieRepository : IRepository<Movie>
    {
        private readonly VROSDbContext _context;
        private readonly DbSet<Movie> _movies;

        public EFMovieRepository(DbContext context)
        {
            _context = (VROSDbContext?)(context ?? throw new ArgumentNullException(nameof(context)));
            _movies = _context.Set<Movie>();
        }

        public async Task AddAsync(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            await _movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await _movies.FindAsync(id);
            if (movie != null)
            {
                _movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _movies.ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _movies.FindAsync(id);
        }

        public async Task UpdateAsync(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            var existing = await _movies.FindAsync(movie.Id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
