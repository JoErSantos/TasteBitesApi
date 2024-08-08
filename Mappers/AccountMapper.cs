using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasteBitesApi.Dtos.Account;
using TasteBitesApi.Models;

namespace TasteBitesApi.Mappers
{
    public static class AccountMapper
    {
        public static NewUserDto ToNewUserDto(this User user, string token)
        {
            return new NewUserDto()
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = token
            };
        }   
    }
}