using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VROS.Domain.Enums;

namespace VROS.Domain
{
    public class Cast : BaseEntity
    {
        public int MovieId { get; set; }    
        public string Name { get; set; }
        public MoviePart Part { get; set; }
    }
}
