using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VROS.DataAccess;
using VROS.Domain;
using VROS.Domain.Enums;

namespace VROS.DataAccess.EFRepository
{
    public class EFUserRepository 
    {
        private readonly VROSDbContext _context;

        public EFUserRepository(VROSDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByCardNumberAsync(string cardNumber)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.CardNumber == cardNumber);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email != null && u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (user == null)
                throw new InvalidOperationException("User not found.");
            return user;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> IsAdminAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return user != null && user.Roles == UserRoles.Admin;
        }

        public async Task UpdateAsync(User entity)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == entity.Id);
            if (user != null)
            {
                user.FullName = entity.FullName;
                user.Age = entity.Age;
                user.CardNumber = entity.CardNumber;
                user.CreatedOn = entity.CreatedOn;
                user.IsSubscriptionExpired = entity.IsSubscriptionExpired;
                user.SubscriptionType = entity.SubscriptionType;
                user.Roles = entity.Roles;
                await _context.SaveChangesAsync();
            }
        }
    }
}
