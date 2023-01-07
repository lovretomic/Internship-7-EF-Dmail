using Dmail.Data.Entities.Models;
using Dmail.Domain.Factories;
using Dmail.Domain.Repositories;
using Dmail.Domain.UserData;
using Dmail.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Menus.MainMenuOptions
{
    public class SpamInboxMenu
    {
        public void Open(User connectedUser)
        {
            var userItemRepository = new UserItemRepository(DbContextFactory.GetDbContext());
            var userRepository = new UserRepository(DbContextFactory.GetDbContext());
            var itemRepository = new ItemRepository(DbContextFactory.GetDbContext());
            int input;

            Writer.PrintHeader();
            var spamInbox = userItemRepository.GetSpamInbox(connectedUser);
            var i = 0;
            foreach (var item in spamInbox)
            {
                Console.WriteLine($"{++i} - {item.Title} - {userRepository.GetById(item.SenderId).Email}");
            }
            if (i == 0)
            {
                Writer.NoResults();
            }
            do
            {
                Console.Write("Unesi broj poruke kojoj zeli pristupiti ili 0 za povratak na glavni izbornik: ");
                input = Reader.ReadNumber();
                if (input > 0 && input <= i)
                {
                    Writer.PrintHeader();
                    itemRepository.Print(spamInbox[input - 1], connectedUser);
                    var mainMenu = new MainMenu();
                    mainMenu.Open(connectedUser);
                }
                else if (input == 0)
                {
                    Console.WriteLine("Vracam se na glavni izbornik...");
                    System.Threading.Thread.Sleep(1000);
                    var mainMenu1 = new MainMenu();
                    mainMenu1.Open(connectedUser);
                }
            } while (input < 0 || input > i);
        }
    }
}
