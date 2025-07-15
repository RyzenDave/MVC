using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VROS.Domain
{
    public class Rental : BaseEntity
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime RentedOn { get; set; }
        public DateTime ReturnedOn { get; set; }
    }
}
