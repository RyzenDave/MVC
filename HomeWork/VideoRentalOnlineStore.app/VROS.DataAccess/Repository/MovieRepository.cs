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
        public Task AddAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
