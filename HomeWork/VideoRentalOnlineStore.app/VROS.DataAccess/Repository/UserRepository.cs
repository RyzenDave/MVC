using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VROS.DataAccess.Interfaces;
using VROS.Domain;

namespace VROS.DataAccess.Repository
{
    internal class UserRepository : IUserRepository
    {
        public Task AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByCardNumberAsync(string cardNumber)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsAdminAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
