using Dmail.Data.Entities.Models;
using Dmail.Domain.Factories;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Helpers;
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
            var userMessageRepository = new UserMessageRepository(DbContextFactory.GetDbContext());
            var userRepository = new UserRepository(DbContextFactory.GetDbContext());
            int i;
            switch (Reader.ReadNumber())
            {
                case 1:
                    Writer.PrintHeader();
                    var readInbox = userMessageRepository.GetReadInbox(connectedUser);
                    i = 0;
                    foreach(var message in readInbox)
                    {
                        Console.WriteLine($"{++i} - {message.Title} - {userRepository.GetById(message.SenderId).Email}");
                    }
                    break;
                case 2:
                    Writer.PrintHeader();
                    var unreadInbox = userMessageRepository.GetUnreadInbox(connectedUser);
                    i = 0;
                    foreach (var message in unreadInbox)
                    {
                        Console.WriteLine($"{++i} - {message.Title} - {userRepository.GetById(message.SenderId).Email}");
                    }
                    break;
                case 3:
                    Writer.PrintHeader();
                    var query = Reader.ReadString("Unesi trazeni pojam:");
                    var inbox = userMessageRepository.GetInbox(connectedUser);
                    i = 0;
                    foreach(var message in inbox)
                    {
                        if(userRepository.GetById(message.SenderId).Email.Contains(query))
                        {
                            Console.WriteLine($"{++i} - {message.Title} - {userRepository.GetById(message.SenderId).Email}");
                        }
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
