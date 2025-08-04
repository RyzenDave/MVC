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
        public static MovieDetailVM ToDetailVM(this Movie movie)
        {
            return movie.ToDetailVM(canRent: false);
        }

        public static MovieDetailVM ToDetailVM(this Movie movie, bool canRent)
        {
            return new MovieDetailVM
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre.ToString(),
                Language = movie.Language.ToString(),
                ReleaseDate = movie.ReleaseDate,
                Length = (int)movie.Length.TotalMinutes,
                AgeRestriction = movie.AgeRestriction.ToString(),
                Quantity = movie.Quantity,
                CanRent = canRent
            };
        }
    }
}
