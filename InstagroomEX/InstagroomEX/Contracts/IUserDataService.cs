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
    }
}
