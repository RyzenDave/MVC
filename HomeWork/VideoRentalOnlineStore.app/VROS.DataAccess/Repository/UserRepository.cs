using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VROS.DataAccess.Interfaces;
using VROS.Domain;
using VROS.Domain.Enums;

namespace VROS.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task AddAsync(User entity)
        {
            entity.Id = StaticDb.Users.Count + 1;
            StaticDb.Users.Add(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                StaticDb.Users.Remove(user);
            }
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<User>>(StaticDb.Users);
        }

        public Task<User?> GetByCardNumberAsync(string cardNumber)
        {
            var user = StaticDb.Users.FirstOrDefault(c => c.CardNumber == cardNumber);
            return Task.FromResult<User?>(user);
        }

        public Task<User> GetByEmailAsync(string email)
        {
            var user = StaticDb.Users.FirstOrDefault(u => u.Email != null && u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (user == null)
                throw new InvalidOperationException("User not found.");
            return Task.FromResult(user);
        }

        public Task<User?> GetByIdAsync(int id)
        {
            var user = StaticDb.Users.FirstOrDefault(u => u.Id == id);
            return Task.FromResult<User?>(user);
        }

        public Task<bool> IsAdminAsync(int userId)
        {
            var user = StaticDb.Users.FirstOrDefault(u => u.Id == userId);
            return Task.FromResult(user != null && user.Roles == UserRoles.Admin);
        }

        public Task UpdateAsync(User entity)
        {
            var user = StaticDb.Users.FirstOrDefault(u => u.Id == entity.Id);
            if (user != null)
            {
                user.FullName = entity.FullName;
                user.Age = entity.Age;
                user.CardNumber = entity.CardNumber;
                user.CreatedOn = entity.CreatedOn;
                user.IsSubscriptionExpired = entity.IsSubscriptionExpired;
                user.SubscriptionType = entity.SubscriptionType;
                user.Roles = entity.Roles;
            }
            return Task.CompletedTask;
        }
    }
}
