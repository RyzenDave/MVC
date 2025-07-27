using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VROS.VM
{
    public class MovieListVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable => Quantity > 0;
        public int Quantity { get; set; }
    }
}
