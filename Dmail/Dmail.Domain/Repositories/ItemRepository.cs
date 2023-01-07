using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Dmail.Data.Enums;
using Dmail.Domain.Enums;
using Dmail.Domain.Factories;
using Dmail.Domain.UserData;
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
        public void Print(Item item, User user, bool outbox = false)
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
                Console.WriteLine(item.Content + "\n");
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

                Console.WriteLine(userItemRepository.GetEventStatus(item));
            }
            if (!outbox)
            {
                PrintOptions(item, user);
            }
            else PrintOutboxOption(item, user);
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
            Console.WriteLine("4 - Odgovori na mail");
            Console.WriteLine("0 - Povratak na ulaznu postu");
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
                case 4:
                    var itemRepository = new ItemRepository(DbContextFactory.GetDbContext());
                    itemRepository.NewMessage(user);
                    break;
                default: break;
            }
        }

        public void PrintOutboxOption(Item item, User user)
        {
            var userItemRepository = new UserItemRepository(DbContext);
            Console.WriteLine("1 - Izbrisi mail");
            Console.WriteLine("0 - Povratak na ulaznu postu");
            switch (Reader.ReadNumber())
            {
                case 1:
                    userItemRepository.Delete(item, user);
                    break;
                default: break;
            }
        }

        public int GetLastItemId()
        {
            return DbContext.Items.Count();
        }

        public ActionStatus NewMessage(User user)
        {
            Writer.PrintHeader();
            var receiversInput = Reader.ReadReceivers("Emailovi primatelja (odvoji zarezom):");
            var titleInput = Reader.ReadString("Naslov:");
            var contentInput = Reader.ReadString("Sadržaj:\n");
            var newId = GetLastItemId() + 1;

            DateTime now = DateTime.UtcNow.Date;
            DbContext.Items.Add(new Item(titleInput, now.ToString("yyyy-MM-dd"), user.Id, ItemType.Message)
            {
                Id = newId,
                Content = contentInput,
                StartDate = ""
            });

            int input;
            Console.Write("Unesi 1 za potvrdu slanja poruke: ");
            input = Reader.ReadNumber();

            if(input == 1)
                foreach (var receiverId in receiversInput)
                {
                    DbContext.UserItems.Add(new UserItem(receiverId, newId)
                    {
                        Attendance = EventStatus.Unknown,
                        Status = MessageStatus.Sent,
                        IsSpam = false
                    });;
                }

            return SaveChanges();
        }

        public ActionStatus NewEvent(User user)
        {
            Writer.PrintHeader();
            var receiversInput = Reader.ReadReceivers("Emailovi primatelja (odvoji zarezom):");
            var titleInput = Reader.ReadString("Naslov:");
            var dateInput = Reader.ReadString("Datum i vrijeme (gggg-mm-dd hh:mm:ss):");
            var newId = GetLastItemId() + 1;

            int input;
            Console.Write("Unesi 1 za potvrdu slanja dogadaja: ");
            input = Reader.ReadNumber();

            if (input == 1)
            {
                DateTime now = DateTime.UtcNow.Date;
                DbContext.Items.Add(new Item(titleInput, now.ToString("yyyy-MM-dd"), user.Id, ItemType.Event)
                {
                    Id = newId,
                    Content = "",
                    StartDate = dateInput
                });

                foreach (var receiverId in receiversInput)
                {
                    DbContext.UserItems.Add(new UserItem(receiverId, newId)
                    {
                        Attendance = EventStatus.Unknown,
                        Status = MessageStatus.Sent,
                        IsSpam = false
                    }); ;
                }
            }
            

            return SaveChanges();
        }

        public Item? GetById(int id) => DbContext.Items.FirstOrDefault(u => u.Id == id);
        public List<Item> GetOutbox(User user)
        {
            var items = DbContext.Items
                .Where(u => u.SenderId == user.Id)
                .ToList();
            return items;
        }

        public List<string> GetSentAdresses(User user)
        {
            var userItemRepository = new UserItemRepository(DbContext);
            var userRepository = new UserRepository(DbContext);
            var items = DbContext.Items
                .Where(u => u.SenderId == user.Id)
                .ToList();

            var userItems = DbContext.UserItems.ToList();
            var adresses = new List<string>();
            foreach (var item in items)
            {
                foreach(var userItem in userItems)
                {
                    if (item.Id == userItem.ItemId)
                    {
                        adresses.Add(userRepository.GetById(userItem.UserId).Email);
                    }
                }
            }

            return adresses;
        }
    }
}
