using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VROS.VM
{
    public class MovieDetailVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Length { get; set; }
        public string AgeRestriction { get; set; }
        public int Quantity { get; set; }

        public bool CanRent => Quantity > 0;
    }
}
