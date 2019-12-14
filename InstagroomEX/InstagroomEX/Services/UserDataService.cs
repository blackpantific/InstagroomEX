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
        public UserDataService(ISQLiteConnectionService connectionService)
        {
            _dbConnection = connectionService.GetConnection();
            _dbConnection.CreateTableAsync<User>();
        }
    }
}
