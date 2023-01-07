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
    public class OutboxMenu
    {
        public void Open(User connectedUser)
        {
            var userItemRepository = new UserItemRepository(DbContextFactory.GetDbContext());
            var userRepository = new UserRepository(DbContextFactory.GetDbContext());
            var itemRepository = new ItemRepository(DbContextFactory.GetDbContext());

            Writer.PrintHeader();
            var outbox = itemRepository.GetOutbox(connectedUser);
            var i = 0;
            int input;
            foreach (var item in outbox)
            {
                Console.WriteLine($"{++i} - {item.Title} - {userItemRepository.GetReceiversEmails(item)}");
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
                    itemRepository.Print(outbox[input - 1], connectedUser);
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
