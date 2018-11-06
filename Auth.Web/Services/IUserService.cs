﻿using System.Threading.Tasks;

namespace Auth.Web.Services
{
    public interface IUserService
    {
        Task<bool> ValidateCredentials(string username, string password, out User user);
        Task<bool> AddUser(string username, string password);
    }

    public class User
    {
        public User(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
    }
}