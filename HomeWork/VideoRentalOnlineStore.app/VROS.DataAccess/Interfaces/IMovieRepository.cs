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
       
            // A promise to get a single movie by its ID
            Task<Movie> GetByIdAsync(int id);

            // A promise to get all movies
            Task<IEnumerable<Movie>> GetAllAsync();

            // A promise to add a new movie
            Task AddAsync(Movie movie);

            // A promise to update an existing movie
            void Update(Movie movie);

            // A promise to delete a movie
            void Delete(Movie movie);
        
    }
}
