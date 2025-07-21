using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VROS.Domain;

namespace VROS.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByCardNumberAsync(string cardNumber);
        Task<User> GetByEmailAsync(string email);
        Task<bool> IsAdminAsync(int userId);
    }
}
