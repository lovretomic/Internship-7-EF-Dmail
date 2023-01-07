using Dmail.Data.Entities.Models;
using Dmail.Domain.Factories;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Menus
{
    public class MainMenu
    {
        public void Open(User connectedUser)
        {
            Writer.PrintHeader();
            Console.WriteLine("1 - Ulazna posta");
            Console.WriteLine("2 - Izlazna posta");
            Console.WriteLine("3 - Spam");
            Console.WriteLine("4 - Posalji novi mail");
            Console.WriteLine("5 - Posalji novi dogadaj");
            Console.WriteLine("6 - Postavke profila");
            Console.WriteLine("7 - Odjava iz profila");
            Console.WriteLine("0 - Izlazak iz aplikacije");

            switch(Reader.ReadNumber())
            {
                case 1:
                    Writer.PrintHeader();
                    Console.WriteLine("ULAZNA POSTA");
                    var userMessageRepository = new UserMessageRepository(DbContextFactory.GetDbContext());
                    var messages = userMessageRepository.GetInbox(connectedUser);
                    foreach(var message in messages)
                    {
                        Console.WriteLine(message.Title);
                        Console.WriteLine(message.Id);
                        Console.WriteLine(message.SentOn);
                        Console.WriteLine(message.Content);
                    }
                    break;
            }
        }
    }
}
