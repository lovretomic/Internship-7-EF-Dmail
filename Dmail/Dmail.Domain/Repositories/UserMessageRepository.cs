using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Dmail.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Domain.Repositories
{
    public class UserMessageRepository : Repository
    {
        public UserMessageRepository(DmailDbContext dbContext) : base(dbContext)
        {
        }

        public List<Message> GetReadInbox(User user)
        {
            var userMessages = DbContext.UserMessages
                .Where(u => u.UserId == user.Id)
                .ToList();
            var messages = DbContext.Messages.ToList();

            var result = new List<Message>();

            foreach(var userMessage in userMessages)
            {
                foreach(var message in messages)
                {
                    if(userMessage.MessageId == message.Id && userMessage.Status == MessageStatus.Read)
                    {
                        result.Add(message);
                    }
                }
            }
            return result;
        }

        public List<Message> GetUnreadInbox(User user)
        {
            var userMessages = DbContext.UserMessages
                .Where(u => u.UserId == user.Id)
                .ToList();
            var messages = DbContext.Messages.ToList();

            var result = new List<Message>();

            foreach (var userMessage in userMessages)
            {
                foreach (var message in messages)
                {
                    if (userMessage.MessageId == message.Id && userMessage.Status == MessageStatus.Sent)
                    {
                        result.Add(message);
                    }
                }
            }
            return result;
        }
    }
}
