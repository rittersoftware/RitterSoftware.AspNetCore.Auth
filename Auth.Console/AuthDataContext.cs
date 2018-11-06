using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth.Console
{
    public class AuthDataContext : IdentityDbContext
    {
        public AuthDataContext(DbContextOptions options) : base(options)
        {
        }

        public AuthDataContext()
        {

        }
    }
}