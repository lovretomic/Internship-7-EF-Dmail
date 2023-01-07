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

        public User? GetByLoginData(string email, string password)
        {
            var users = DbContext.Users
                .Where(u => u.Email == email)
                .Where(u => u.Password == password)
                .ToList();

            if (users.Any()) { return users[0]; }
            else { return null; }
        }

        public User? GetByEmail(string email)
        {
            var users = DbContext.Users
                .Where(u => u.Email == email)
                .ToList();

            if (users.Any()) { return users[0]; }
            else { return null; }
        }

        public ActionStatus Add(User user)
        {
            DbContext.Users.Add(user);
            return SaveChanges();
        }
        public User? GetById(int id) => DbContext.Users.FirstOrDefault(u => u.Id == id);
    }
}
