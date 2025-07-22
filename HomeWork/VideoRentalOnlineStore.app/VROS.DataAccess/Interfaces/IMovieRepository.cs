using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VROS.Domain;

namespace VROS.DataAccess.Interfaces
{
        public interface IMovieRepository
        {
            Task<Movie> GetByIdAsync(int id);
            Task<IEnumerable<Movie>> GetAllAsync();
            Task AddAsync(Movie movie);
            Task UpdateAsync(Movie movie);
            Task DeleteAsync(Movie movie);
        }
}
