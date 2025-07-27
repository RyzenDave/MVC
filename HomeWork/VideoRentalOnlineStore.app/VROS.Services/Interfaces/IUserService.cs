using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VROS.Domain;
using VROS.Dto;

namespace VROS.Services.Interfaces
{
    public interface IUserService
    {  
     Task<User?> ValidateUserAsync(string email, string cardNumber);
     Task<User> RegisterUserAsync(UserRegisterDto dto);
    
    }
}
