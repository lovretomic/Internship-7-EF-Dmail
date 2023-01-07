using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Dmail.Data.Enums;
using Dmail.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Domain.Repositories
{
    public class MessageRepository : Repository
    {
        public MessageRepository(DmailDbContext dbContext) : base(dbContext)
        {
        }
        /*
        public void Print(Message message)
        {
            SetToRead(message);
            var userRepository = new UserRepository(DbContext);
            var sender = userRepository.GetById(message.SenderId);
            Console.WriteLine("");
            Console.WriteLine(message.Title);
            Console.WriteLine(message.SentOn);
            Console.WriteLine(sender.FirstName + " " + sender.LastName + " (" + sender.Email + ")");
            Console.WriteLine("----------");
            Console.WriteLine(message.Content);
        }
        
        private ActionStatus SetToRead(Message message)
        {
            var messageToUpdate = DbContext.UserMessages.FirstOrDefault(m => m.MessageId == message.Id);
            if (messageToUpdate is null)
            {
                return ActionStatus.NoChanges;
            }

            messageToUpdate.Status = MessageStatus.Read;
            return SaveChanges();
        }
        */
    }
}
