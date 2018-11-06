using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Auth.Console
{
    public class Program
    {
        private static AuthDataContext _context;

        public static void Main(string[] args)
        {
            _context = new AuthDataContext();
            
        }

        public void CreateNewUserStore()
        {

        }
    }
}
