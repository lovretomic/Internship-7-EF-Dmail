using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Dmail.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Domain.Repositories
{
    public class SpamAdressRepository : Repository
    {
        public SpamAdressRepository(DmailDbContext dbContext) : base(dbContext)
        {
        }

        public ActionStatus Add(int userId1, int userId2)
        {
            DbContext.SpamAdresses.Add(new SpamAdress()
            {
                User1Id = userId1,
                User2Id = userId2
            });
            return SaveChanges();
        }

        public ActionStatus Remove(int userId1, int userId2)
        {
            var adressToRemove = DbContext.SpamAdresses
                .Where(sa => sa.User1Id == userId1)
                .Where(sa => sa.User2Id == userId2)
                .ToList();

            DbContext.SpamAdresses.Remove(adressToRemove[0]);
            return SaveChanges();
        }

        public List<string> GetSpamAdresses(int userId)
        {
            var userRepository = new UserRepository(DbContext);
            var adresses = DbContext.SpamAdresses
                .Where(sa => sa.User1Id == userId)
                .ToList();

            var output = new List<string>();

            foreach(var adress in adresses)
            {
                output.Add(userRepository.GetById(adress.User2Id).Email);
            }

            return output;
        }
    }
}
