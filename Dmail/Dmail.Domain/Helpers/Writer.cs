using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Helpers
{
    public static class Writer
    {
        public static void PrintHeader()
        {
            Console.Clear();
            Console.WriteLine("--- Dmail ---");
        }

        public static void PrintInputError(string message)
        {
            Console.WriteLine("## Pogresan unos! " + message);
        }

        public static void PrintError(string message)
        {
            Console.WriteLine("## " + message);
        }
    }
}
