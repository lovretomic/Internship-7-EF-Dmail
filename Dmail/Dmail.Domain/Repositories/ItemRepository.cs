using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Dmail.Data.Enums;
using Dmail.Domain.Enums;
using Dmail.Presentation.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Domain.Repositories
{
    public class ItemRepository : Repository
    {
        public ItemRepository(DmailDbContext dbContext) : base(dbContext)
        {
        }
        public void Print(Item item, User user)
        {
            SetToRead(item);
            var userRepository = new UserRepository(DbContext);
            var userItemRepository = new UserItemRepository(DbContext);
            var sender = userRepository.GetById(item.SenderId);

            Console.WriteLine("");
            if (item.Type is ItemType.Message)
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.SentOn);
                Console.WriteLine(sender.FirstName + " " + sender.LastName + " (" + sender.Email + ")");
                Console.WriteLine("----------");
                Console.WriteLine(item.Content);
            }
            else
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.StartDate);
                Console.WriteLine(sender.FirstName + " " + sender.LastName + " (" + sender.Email + ")");

                var receivers = userItemRepository.GetReceivers(item);
                foreach(var receiver in receivers)
                {
                    Console.WriteLine(receiver.FirstName + " " + receiver.LastName + " (" + receiver.Email + ")");
                }

                Console.WriteLine(userItemRepository.GetEventStatus(item, user));
            }
            PrintOptions(item, user);
        }

        private ActionStatus SetToRead(Item item)
        {
            var itemToUpdate = DbContext.UserItems.FirstOrDefault(m => m.ItemId == item.Id);
            if (itemToUpdate is null)
            {
                return ActionStatus.NoChanges;
            }

            itemToUpdate.Status = MessageStatus.Read;
            return SaveChanges();
        }
        private ActionStatus SetToUnread(Item item)
        {
            var itemToUpdate = DbContext.UserItems.FirstOrDefault(m => m.ItemId == item.Id);
            if (itemToUpdate is null)
            {
                return ActionStatus.NoChanges;
            }

            itemToUpdate.Status = MessageStatus.Sent;
            return SaveChanges();
        }
        private ActionStatus SetToSpam(Item item, User user)
        {
            var itemToUpdate = DbContext.UserItems
                .Where(ui => ui.ItemId == item.Id)
                .Where(ui => ui.UserId == user.Id)
                .ToList()[0];

            if (itemToUpdate is null)
            {
                return ActionStatus.NoChanges;
            }

            itemToUpdate.IsSpam = true;
            return SaveChanges();
        }

        public void PrintOptions(Item item, User user)
        {
            var userItemRepository = new UserItemRepository(DbContext);
            Console.WriteLine("1 - Oznaci kao neprocitano");
            Console.WriteLine("2 - Oznaci kao spam");
            Console.WriteLine("3 - Izbrisi mail");
            Console.WriteLine("4 - Odgovori na mail"); // Not implemented
            Console.WriteLine("0 - Povratak na ulaznu postu"); // Not implemented
            switch (Reader.ReadNumber())
            {
                case 1:
                    SetToUnread(item);
                    break;
                case 2:
                    SetToSpam(item, user);
                    break;
                case 3:
                    userItemRepository.Delete(item, user);
                    break;
            }
        }
    }
}
