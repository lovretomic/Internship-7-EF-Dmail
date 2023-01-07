using Dmail.Data.Entities.Models;
using Dmail.Domain.Factories;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            var userRepository = new UserRepository(DbContextFactory.GetDbContext());
            Writer.PrintHeader();

            var allAdresses = new List<string>();
            int i = 0;

            Console.WriteLine("\nAdrese koje su Vam slale poruku:");
            var senders = userItemRepository.GetReceivedSenders(connectedUser).Distinct().ToList();
            foreach (var sender in senders)
            {
                Console.WriteLine($"{++i} - {sender.Email}");
                allAdresses.Add(sender.Email);
            }
                  
            Console.WriteLine("\nAdrese kojima ste Vi slali poruku:");
            var adresses = itemRepository.GetSentAdresses(connectedUser).Distinct().ToList();
            foreach (var adress in adresses)
            {
                Console.WriteLine($"{++i} - {adress}");
                allAdresses.Add(adress);
            }

            var spamAdressRepository = new SpamAdressRepository(DbContextFactory.GetDbContext());

            Console.Write("Unesi broj adrese koju zelis oznaciti kao spam adresu ili 0 za povratak na glavni izbornik: ");
            var allSpamAdresses = spamAdressRepository.GetSpamAdresses(connectedUser.Id);
            var input = Reader.ReadNumber();
            if (input == 0)
            {
                Console.WriteLine("Vracam se na glavni izbornik...");
                System.Threading.Thread.Sleep(1000);
                var mainMenu1 = new MainMenu();
                mainMenu1.Open(connectedUser);
            }
            else if (input - 1 < allAdresses.Count())
            {
                if(allSpamAdresses.Contains(allAdresses[input - 1]))
                {
                    spamAdressRepository.Add(connectedUser.Id, userRepository.GetByEmail(allAdresses[input - 1]).Id);
                    Console.WriteLine("Adresa dodana kao spam!");
                }
                else
                {
                    spamAdressRepository.Remove(connectedUser.Id, userRepository.GetByEmail(allAdresses[input - 1]).Id);
                    Console.WriteLine("Adresa uklonjena kao spam!");
                }
            }

        }
    }
}
