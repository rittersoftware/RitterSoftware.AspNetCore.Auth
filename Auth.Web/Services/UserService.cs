using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth.Web.Services
{
    public class UserService : IUserService
    {
        private IDictionary<string, (string PasswordHash, User User)> _users = new ConcurrentDictionary<string, (string PasswordHash, User User)>();

        public UserService(IDictionary<string, string> users)
        {
            foreach (var user in users)
            {
                _users.Add(user.Key.ToLower(),(BCrypt.Net.BCrypt.HashPassword(user.Value), new User(user.Key.ToLower())));
            }
        }

        public Task<bool> ValidateCredentials(string username, string password, out User user)
        {
            user = null;
            var key = username.ToLower();
            throw new System.NotImplementedException();
        }

        public Task<bool> AddUser(string username, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}