using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VROS.Dto
{
    public class UserRegisterDto
    {
        [Required] public string FullName { get; set; }
        [Required] public int Age { get; set; } 
        [Required] public string CardNumber { get; set; }
        [Required][EmailAddress] public string Email { get; set; }
    }
}
