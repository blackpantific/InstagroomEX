using InstagroomEX.Contracts;
using InstagroomEX.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstagroomEX.Services
{
    public class UserDataService : IUserDataService
    {
        private SQLiteAsyncConnection _dbConnection;
        public User CurrentUser { get; set; }

        public async Task<bool> AddUserAsync(User newUser)
        {
            try
            {
                await _dbConnection.InsertAsync(newUser);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<User> GetUserByIDAsync(int userId)
        {
            return await _dbConnection.GetAsync<User>(u => (u.ID == userId));
        }

        public async Task<bool> UpdateUserAsync(User updUser)
        {
            try
            {
                await _dbConnection.UpdateAsync(updUser);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            try
            {  
                var user = await _dbConnection.GetAsync<User>(u => (u.Username == username));
                return user;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public async Task<User> GetUserByGoogleIDAsync(string googleId)
        {
            return await _dbConnection.GetAsync<User>(u => (u.GoogleID == googleId));
        }

        public string GetUserFullName(User user)
        {
            return user.FirstName + " " + user.LastName;
        }

        public UserDataService(ISQLiteConnectionService connectionService)
        {
            _dbConnection = connectionService.GetConnection();
            _dbConnection.CreateTableAsync<User>();
        }
    }
}
/*namespace InstagroomEX.Services
{
    public class UserDataService : IUserDataService
    {
        private SQLiteAsyncConnection _dbConnection;
        public UserDto CurrentUser { get; set; }

        public async Task<bool> AddUserAsync(User newUser)
        {
            try
            {
                await _dbConnection.InsertAsync(newUser);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<UserDto> GetUserByIDAsync(int userId)
        {
            var resultUser =  await _dbConnection.GetAsync<User>(u => (u.ID == userId));
            return resultUser.ToUserDto();
        }

        public async Task<bool> UpdateUserAsync(UserDto updUser)
        {
            var userDto = updUser.ToUser();
            
            try
            {
                await _dbConnection.UpdateAsync(userDto);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<UserDto> GetUserByUsernameAsync(string username)
        {
            try
            {  
                var user = await _dbConnection.GetAsync<User>(u => (u.Username == username));
                return user.ToUserDto();
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public async Task<UserDto> GetUserByGoogleIDAsync(string googleId)
        {
            return (await _dbConnection.GetAsync<User>(u => (u.GoogleID == googleId))).ToUserDto();
        }

        public string GetUserFullName(UserDto user)
        {
            return user.FirstName + " " + user.LastName;
        }

        public UserDataService(ISQLiteConnectionService connectionService)
        {
            _dbConnection = connectionService.GetConnection();
            _dbConnection.CreateTableAsync<User>();
        }
    }
}*/
