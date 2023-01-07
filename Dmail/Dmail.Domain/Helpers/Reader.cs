using Dmail.Domain.Factories;
using Dmail.Domain.Repositories;
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

        public static List<int> ReadReceivers(string message)
        {
            var userRepository = new UserRepository(DbContextFactory.GetDbContext());
            Console.Write(message + " ");
            var input = Console.ReadLine();

            var splitted = input.Split(',').ToList();
            for(int i = 0; i < splitted.Count(); i++)
            {
                splitted[i] = splitted[i].Trim();
            }

            var ids = new List<int>();
            foreach(var part in splitted)
            {
                if(!userRepository.EmailIsUnique(part))
                    ids.Add(userRepository.GetByEmail(part).Id);
            }

            return ids;
        }
    }
}
