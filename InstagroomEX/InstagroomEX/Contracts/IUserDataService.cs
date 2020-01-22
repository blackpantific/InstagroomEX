using InstagroomEX.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstagroomEX.Contracts
{
    public interface IUserDataService
    {
        User CurrentUser { get; set; }

        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserByIDAsync(int userId);
        Task<bool> AddUserAsync(User newUser);
        Task<User> GetUserByGoogleIDAsync(string googleId);
        Task<bool> UpdateUserAsync(User updUser);
        string GetUserFullName(User user);
    }
}

/*public interface IUserDataService
    {
        UserDto CurrentUser { get; set; }

        Task<UserDto> GetUserByUsernameAsync(string username);
        Task<UserDto> GetUserByIDAsync(int userId);
        Task<bool> AddUserAsync(User newUser);
        Task<UserDto> GetUserByGoogleIDAsync(string googleId);
        Task<bool> UpdateUserAsync(UserDto updUser);
        string GetUserFullName(UserDto user);
    }*/
