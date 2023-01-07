using Dmail.Data.Entities.Models;
using Dmail.Domain.Factories;
using Dmail.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Presentation.Menus.MainMenuOptions
{
    public class NewMessageMenu
    {
        public void Open(User connectedUser)
        {
            var itemRepository = new ItemRepository(DbContextFactory.GetDbContext());
            itemRepository.NewMessage(connectedUser);
            var mainMenu = new MainMenu();
            mainMenu.Open(connectedUser);
        }
    }
}
