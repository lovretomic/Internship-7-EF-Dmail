using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Dmail.Domain.Enums;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Domain.Repositories
{
    public class UserRepository : Repository
    {
        public UserRepository(DmailDbContext dbContext) : base(dbContext)
        {
        }

        public bool Contains(string email, string password)
        {
            var user = DbContext.Users
                .Where(u => u.Email == email)
                .Where(u => u.Password == password)
                .ToList();

            if (user.Any()) { return true; }
            else { return false; }
        }

        public ActionStatus Add(User user)
        {
            DbContext.Users.Add(user);
            return SaveChanges();
        }
    }
}
