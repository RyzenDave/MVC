using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VROS.Domain;
using VROS.Domain.Enums;
using VROS.Dto;

namespace VROS.Mapper
{
    public static class UserMapper
    {
        public static User ToEntity(this UserRegisterDto dto)
        {
            return new User
            {
                Id = 0, // Will be set by repo
                FullName = dto.FullName,
                Age = dto.Age,
                CardNumber = dto.CardNumber,
                Email = dto.Email,
                CreatedOn = DateTime.Now,
                IsSubscriptionExpired = false,
                SubscriptionType = SubscriptionType.Free,
                Roles = UserRoles.User
            };
        }
    }
}
