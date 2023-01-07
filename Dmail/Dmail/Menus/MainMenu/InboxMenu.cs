using Dmail.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Menus.MainMenu
{
    public class InboxMenu
    {
        public void Open()
        {
            Writer.PrintHeader();
            Console.WriteLine("1 - Procitana posta");
            Console.WriteLine("2 - Neprocitana posta");
            Console.WriteLine("3 - Posta od odredenog positaljelja");
            Console.WriteLine("0 - Povratak na glavni izbornik");

            switch(Reader.ReadNumber())
            {
                case 1: break;
            }
        }
    }
}
