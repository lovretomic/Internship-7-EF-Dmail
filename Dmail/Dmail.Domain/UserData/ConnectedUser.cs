using Dmail.Data.Entities;
using Dmail.Domain.Enums;
using Dmail.Domain.Factories;
using Dmail.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Domain.UserData
{
    public class ConnectedUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ActionStatus Connect(int id)
        {
            var userRepository = new UserRepository(DbContextFactory.GetDbContext());
            var user = userRepository.GetById(id);

            if (user is not null)
            {
                Id = user.Id;
                FirstName = user.FirstName;
                LastName = user.LastName;
                Email = user.Email;
                Password = user.Password;
                return ActionStatus.Success;
            }
            else return ActionStatus.Failed;
        }
    }
}
