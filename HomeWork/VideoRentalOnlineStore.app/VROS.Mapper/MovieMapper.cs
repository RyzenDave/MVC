using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VROS.Domain;
using VROS.VM;

namespace VROS.Mapper
{
    public static class MovieMapper
    {
        public static MovieListVM ToListVM(Movie movie)
        {
            return new MovieListVM
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre.ToString(), // Convert enum to string
                Quantity = movie.Quantity
            };
        }
        public static void UpdateMovieFromEdit(Movie existing, Movie movie)
        {
            existing.Title = movie.Title;
            existing.Genre = movie.Genre;
            existing.Language = movie.Language;
            existing.ReleaseDate = movie.ReleaseDate;
            existing.Length = movie.Length;
            existing.AgeRestriction = movie.AgeRestriction;
            existing.Quantity = movie.Quantity;
        }
    }
}

