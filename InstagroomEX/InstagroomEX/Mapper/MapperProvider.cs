using InstagroomEX.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstagroomEX.Mapper
{
    public static class MapperProvider
    {
        public static User ToUser(this UserDto dto)
        {
            var user = new User
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                GoogleID = dto.GoogleID,
                ID = dto.ID,
                LastName = dto.LastName,
                Password = dto.Password,
                UserAvatar = dto.UserAvatar,
                Username = dto.Username
            };

            return user;
        }

        public static UserDto ToUserDto(this User dto)
        {
            var userDto = new UserDto
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                GoogleID = dto.GoogleID,
                ID = dto.ID,
                LastName = dto.LastName,
                Password = dto.Password,
                UserAvatar = dto.UserAvatar,
                Username = dto.Username
            };

            return userDto;
        }
    }
}
