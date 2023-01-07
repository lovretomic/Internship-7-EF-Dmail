using Dmail.Data.Entities.Models;
using Dmail.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Data.Seeds
{
    public static class InitialSeed
    {
        private static int MaxUserId = 0;
        private static int MaxMessageEventId = 0;
        public static void Seed(ModelBuilder builder)
        {
            
            builder.Entity<User>()
                .HasData(new List<User>
                {
                    new User("Jadranka", "Lovrić", "jadrankalovric@gmail.com", "QJpzGc94Vf7P")
                    {
                        Id = 1
                    },
                    new User("Mate", "Jerković", "mate.jerkovic@gmail.com", "4K3fgnoj7T3V")
                    {
                        Id = 2
                    },
                    new User("Dragoslav", "Herceg", "hercegdragoslav@gmail.com", "QsoCrT4CqErv")
                    {
                        Id = 3
                    },
                    new User("Ranka", "Vukoja", "vukojaranka90@hotmail.com", "y45LRkBQjtmg")
                    {
                        Id = 4
                    },
                    new User("Helena", "Knežević", "helenaknez@gmail.com", "P5LWdm9sDPnc")
                    {
                        Id = 5
                    },
                    new User("Stjepan", "Lučić", "stipel@gmail.com", "bBQ3mEVXFEHc")
                    {
                        Id = 6
                    },
                    new User("Višnja", "Pavlović", "visnja.pavlovic@gmail.com", "8u8sBshThMnK")
                    {
                        Id = 7
                    },
                    new User("Alen", "Košar", "alenkosar1@gmail.com", "G2TJfh1BgjJo")
                    {
                        Id = 8
                    },
                    new User("Pero", "Nikolić", "nikolic.p@gmail.com", "0nUda4jTo7Ar")
                    {
                        Id = 9
                    },
                    new User("Janko", "Jurić", "jankojuric99@yahoo.com", "vugpkNAzkp6G")
                    {
                        Id = 10
                    },
                    new User("Domagoj", "Jerković", "domagoj.jerko@gmail.com", "b3VigXxiQJkR")
                    {
                        Id = 11
                    },
                    new User("Antonela", "Lučić", "lucicantonela@gmail.com", "WZv4zYpAVszQ")
                    {
                        Id = 12
                    },
                    new User("Adam", "Ivanović", "adam.ivanovic2@gmail.com", "BvHVg4EyWja6")
                    {
                        Id = 13
                    },
                    new User("Bruno", "Pavičić", "brunopavicic@gmail.com", "3jiW5m92eFsb")
                    {
                        Id = 14
                    },
                    new User("Anja", "Perko", "perko.anja09@gmail.com", "qkipaEkfPi2P")
                    {
                        Id = 15
                    }
                });

            builder.Entity<Item>()
                .HasData(new List<Item>
                {
                    new Item("Prijava za sponzora", "2023-01-06", 3, ItemType.Message)
                    {
                        Id = 1,
                        Content = IdGenerator.GetMailDummyText(),
                        StartDate = ""
                    },
                    new Item("Upit", "2023-01-05", 3, ItemType.Message)
                    {
                        Id = 2,
                        Content = IdGenerator.GetMailDummyText(),
                        StartDate = ""
                    },
                    new Item("Dodatne informacije", "2023-01-04", 3, ItemType.Message)
                    {
                        Id = 3,
                        Content = IdGenerator.GetMailDummyText(),
                        StartDate = ""
                    },
                    new Item("Sastanak 1", "2022-12-06", 7, ItemType.Event)
                    {
                        Id = 4,
                        Content = "",
                        StartDate = "2022-12-07"
                    },
                    new Item("Sastanak 2", "2022-12-10", 4, ItemType.Event)
                    {
                        Id = 5,
                        Content = "",
                        StartDate = "2022-12-10"
                    },
                    new Item("Uredivanje prostora", "2022-12-17", 16, ItemType.Event)
                    {
                        Id = 6,
                        Content = "",
                        StartDate = "2022-12-16"
                    },
                    new Item("Predavanje 5", "2022-12-29", 2, ItemType.Event)
                    {
                        Id = 7,
                        Content = "",
                        StartDate = "2022-12-20"
                    }
                });;

            builder.Entity<UserItem>()
                .HasData(new List<UserItem>
                {
                    new UserItem(2, 1){},
                    new UserItem(8, 2){},
                    new UserItem(9, 3){},
                    new UserItem(14, 1){},
                    new UserItem(11, 2){},
                    new UserItem(7, 4){},
                    new UserItem(2, 5){},
                    new UserItem(14, 6){},
                    new UserItem(1, 7){},
                    new UserItem(10, 5){}
                });
        }
    }
}
