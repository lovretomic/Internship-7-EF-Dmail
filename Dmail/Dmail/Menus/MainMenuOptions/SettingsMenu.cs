using Dmail.Data.Entities.Models;
using Dmail.Domain.Factories;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Menus.MainMenuOptions
{
    public class SettingsMenu
    {
        public void Open(User connectedUser)
        {
            var userItemRepository = new UserItemRepository(DbContextFactory.GetDbContext());
            var itemRepository = new ItemRepository(DbContextFactory.GetDbContext());
            Writer.PrintHeader();

            Console.WriteLine("1 - Adrese koje su Vam slale poruku");
            Console.WriteLine("2 - Adrese kojima ste Vi slali poruku");

            switch(Reader.ReadNumber())
            {
                case 1:
                    var senders = userItemRepository.GetReceivedSenders(connectedUser).Distinct().ToList();
                    foreach (var sender in senders)
                    {
                        Console.WriteLine($"- {sender.Email}");
                    }
                    break;
                case 2:
                    var adresses = itemRepository.GetSentAdresses(connectedUser).Distinct().ToList();
                    foreach (var adress in adresses)
                    {
                        Console.WriteLine($"- {adress}");
                    }
                    break;
            }
        }
    }
}
