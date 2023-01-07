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
            foreach (var item in outbox)
            {
                Console.WriteLine($"{++i} - {item.Title} - {userItemRepository.GetReceiversEmails(item)}");
            }
            var input = Reader.ReadNumber();
            if (input - 1 < outbox.Count())
            {
                Writer.PrintHeader();
                itemRepository.Print(outbox[input - 1], connectedUser, true);
            }
        }
    }
}
