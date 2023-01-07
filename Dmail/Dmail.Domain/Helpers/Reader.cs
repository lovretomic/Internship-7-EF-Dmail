using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Helpers
{
    public static class Reader
    {
        public static int ReadNumber()
        {
            int number;
            var isNumber = int.TryParse(Console.ReadLine(), out number);
            if (!isNumber)
                return 0;

            return number;
        }

        public static string ReadString(string message)
        {
            Console.Write(message + " ");
            return Console.ReadLine();
        }
    }
}
