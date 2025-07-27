using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VROS.Dto
{
    public class UserLoginDto
    {
        public string Identifier { get; set; } // CardNumber or Email
        public string Password { get; set; }
    }
}
