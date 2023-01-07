using Dmail.Data.Entities.Models;
using Dmail.Domain.Factories;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Menus.MainMenuOption
{
    public class InboxMenu
    {
        public void Open(User connectedUser)
        {
            Writer.PrintHeader();
            Console.WriteLine("1 - Procitana posta");
            Console.WriteLine("2 - Neprocitana posta");
            Console.WriteLine("3 - Posta od odredenog positaljelja");
            Console.WriteLine("0 - Povratak na glavni izbornik");
            var userItemRepository = new UserItemRepository(DbContextFactory.GetDbContext());
            var userRepository = new UserRepository(DbContextFactory.GetDbContext());
            var itemRepository = new ItemRepository(DbContextFactory.GetDbContext());
            int input;
            int i;
            switch (Reader.ReadNumber())
            {
                case 1:
                    Writer.PrintHeader();
                    var readInbox = userItemRepository.GetReadInbox(connectedUser);
                    i = 0;
                    foreach(var item in readInbox)
                    {
                        Console.WriteLine($"{++i} - {item.Title} - {userRepository.GetById(item.SenderId).Email}");
                    }
                    input = Reader.ReadNumber();
                    if (input - 1 < readInbox.Count())
                    {
                        Writer.PrintHeader();
                        itemRepository.Print(readInbox[input - 1], connectedUser);
                    }
                    break;
                case 2:
                    Writer.PrintHeader();
                    var unreadInbox = userItemRepository.GetUnreadInbox(connectedUser);
                    i = 0;
                    foreach (var item in unreadInbox)
                    {
                        Console.WriteLine($"{++i} - {item.Title} - {userRepository.GetById(item.SenderId).Email}");
                    }
                    input = Reader.ReadNumber();
                    if (input - 1 < unreadInbox.Count())
                    {
                        Writer.PrintHeader();
                        itemRepository.Print(unreadInbox[input - 1], connectedUser);
                    }
                    break;
                case 3:
                    Writer.PrintHeader();
                    var query = Reader.ReadString("Unesi trazeni pojam:");
                    var inbox = userItemRepository.GetInbox(connectedUser);
                    i = 0;
                    foreach(var item in inbox)
                    {
                        if(userRepository.GetById(item.SenderId).Email.Contains(query))
                        {
                            Console.WriteLine($"{++i} - {item.Title} - {userRepository.GetById(item.SenderId).Email}");
                        }
                    }
                    input = Reader.ReadNumber();
                    if (input - 1 < inbox.Count())
                    {
                        Writer.PrintHeader();
                        itemRepository.Print(inbox[input - 1], connectedUser);
                    }
                    break;
                case 0:
                    var mainMenu = new MainMenu();
                    mainMenu.Open(connectedUser);
                    break;
            }
        }
    }
}
