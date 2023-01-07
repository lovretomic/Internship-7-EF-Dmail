using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Dmail.Data.Enums;
using Dmail.Domain.Enums;
using Dmail.Domain.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Domain.Repositories
{
    public class UserItemRepository : Repository
    {
        public UserItemRepository(DmailDbContext dbContext) : base(dbContext)
        {
        }

        public List<User> GetReceivers(Item item)
        {
            var users = DbContext.UserItems
                .Where(u => u.ItemId == item.Id)
                .ToList();

            List<User> receivers = new List<User>();
            var userRepository = new UserRepository(DbContext);

            foreach (var user in users)
            {
                receivers.Add(userRepository.GetById(user.UserId));
            }

            return receivers;
        }

        public string GetReceiversEmails(Item item)
        {
            var users = DbContext.UserItems
                .Where(u => u.ItemId == item.Id)
                .ToList();

            List<User> receivers = new List<User>();
            var userRepository = new UserRepository(DbContext);

            foreach (var user in users)
            {
                receivers.Add(userRepository.GetById(user.UserId));
            }

            var output = "";
            int i = 0;
            foreach(var receiver in receivers)
            {
                if(i != 0) output += ",";
                output += receiver.Email;
                i++;
            }

            return output;
        }

        public List<Item> GetReadInbox(User user)
        {
            var userItems = DbContext.UserItems
                .Where(u => u.UserId == user.Id)
                .ToList();

            var items = DbContext.Items.ToList();
            var result = new List<Item>();

            foreach (var userItem in userItems)
            {
                foreach (var item in items)
                {
                    if (userItem.ItemId == item.Id && userItem.Status == MessageStatus.Read)
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public List<Item> GetUnreadInbox(User user)
        {
            var userItems = DbContext.UserItems
                .Where(u => u.UserId == user.Id)
                .ToList();

            var items = DbContext.Items.ToList();
            var result = new List<Item>();

            foreach (var userItem in userItems)
            {
                foreach (var item in items)
                {
                    if (userItem.ItemId == item.Id && userItem.Status == MessageStatus.Sent)
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public List<Item> GetInbox(User user)
        {
            var userItems = DbContext.UserItems
                .Where(u => u.UserId == user.Id)
                .ToList();

            var items = DbContext.Items.ToList();
            var result = new List<Item>();

            foreach (var userItem in userItems)
            {
                foreach (var item in items)
                {
                    if (userItem.ItemId == item.Id)
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public List<Item> GetSpamInbox(User user)
        {
            var userItems = DbContext.UserItems
                .Where(u => u.UserId == user.Id)
                .ToList();

            var items = DbContext.Items.ToList();
            var result = new List<Item>();

            foreach (var userItem in userItems)
            {
                foreach (var item in items)
                {
                    if (userItem.ItemId == item.Id && userItem.IsSpam)
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public EventStatus GetEventStatus(Item item)
        {
            if (item.Type != ItemType.Event) return EventStatus.Unknown;

            var data = DbContext.UserItems
                .Where(u => u.ItemId == item.Id)
                .ToList();
            if(!data.Any()) return EventStatus.Unknown;
            return data[0].Attendance;
        }

        public ActionStatus Delete(Item item, User user)
        {
            var userItem = DbContext.UserItems
                .Where(u => u.UserId == user.Id)
                .Where(u => u.ItemId == item.Id)
                .ToList();

            DbContext.UserItems.Remove(userItem[0]);
            return SaveChanges();
        }

        public List<User> GetReceivedSenders(User user)
        {
            var itemRepository = new ItemRepository(DbContextFactory.GetDbContext());
            var userRepository = new UserRepository(DbContextFactory.GetDbContext());
            var receivedItems = DbContext.UserItems
                .Where(u => u.UserId == user.Id)
                .ToList();

            var users = new List<User>();
            foreach (var item in receivedItems)
            {
                users.Add(userRepository.GetById(itemRepository.GetById(item.ItemId).SenderId));
            }

            return users;
        }
    }
}
