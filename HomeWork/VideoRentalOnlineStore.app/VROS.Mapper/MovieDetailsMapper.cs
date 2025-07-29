using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VROS.Domain;
using VROS.VM;

namespace VROS.Mapper
{
    public static class MovieDetailsMapper
    {
        public static MovieDetailVM ToDetailVM(Movie movie)
        {
            return new MovieDetailVM
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre.ToString(), // Convert enum to string
                Language = movie.Language.ToString(), // Convert enum to string
                ReleaseDate = movie.ReleaseDate,
                Length = (int)movie.Length.TotalMinutes,
                AgeRestriction = movie.AgeRestriction.ToString(),
                Quantity = movie.Quantity
            };
        }
    }
}
