using Dmail.Data.Entities.Models;
using Dmail.Domain.Factories;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Helpers;
using Dmail.Presentation.Menus.MainMenuOption;
using Dmail.Presentation.Menus.MainMenuOptions;
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
                    var inboxMenu = new InboxMenu();
                    inboxMenu.Open(connectedUser);
                    break;
                case 2:
                    var outboxMenu = new OutboxMenu();
                    outboxMenu.Open(connectedUser);
                    break;
                case 3:
                    var spamInboxMenu = new SpamInboxMenu();
                    spamInboxMenu.Open(connectedUser);
                    break;
                case 4:
                    var newMessageMenu = new NewMessageMenu();
                    newMessageMenu.Open(connectedUser);
                    break;
                case 5:
                    var newEventMenu = new NewEventMenu();
                    newEventMenu.Open(connectedUser);
                    break;
                case 6:
                    var settingsMenu = new SettingsMenu();
                    settingsMenu.Open(connectedUser);
                    break;
                case 7:
                    Console.WriteLine("Odjavljujem...");
                    System.Threading.Thread.Sleep(2000);
                    var loginMenu = new LoginMenu();
                    loginMenu.Open();
                    break;
                default:
                    Console.WriteLine("Dovidenja! Odjavljujem i zatvaram aplikaciju...");
                    System.Threading.Thread.Sleep(2000);
                    return;
                    break;
            }
        }
    }
}
