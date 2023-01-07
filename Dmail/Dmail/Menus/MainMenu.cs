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
                case 3:
                    var spamInboxMenu = new SpamInboxMenu();
                    spamInboxMenu.Open(connectedUser);
                    break;
            }
        }
    }
}
