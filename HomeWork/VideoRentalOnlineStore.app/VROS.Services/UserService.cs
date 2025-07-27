using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VROS.DataAccess.Interfaces;
using VROS.DataAccess.Repository;
using VROS.Domain;
using VROS.Dto;
using VROS.Mapper;
using VROS.Services.Interfaces;
using VROS.VM;


namespace VROS.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> ValidateUserAsync(string email, string cardNumber)
        {
            var user = await _userRepository.GetByCardNumberAsync(cardNumber);
            if (user == null) return null;

            // Now check if this user also has the matching email
            if (user.Email?.Equals(email, StringComparison.OrdinalIgnoreCase) == true)
            {
                return user;
            }

            return null;
        }

        public async Task<User> RegisterUserAsync(UserRegisterDto dto)
        {
            var existingByCard = await _userRepository.GetByCardNumberAsync(dto.CardNumber);
            if (existingByCard != null)
                throw new InvalidOperationException("Card number already taken.");

            var existingByEmail = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingByEmail != null)
                throw new InvalidOperationException("Email already taken.");

            var user = dto.ToEntity();
            await _userRepository.AddAsync(user);
            return user;
        }
    }
}

