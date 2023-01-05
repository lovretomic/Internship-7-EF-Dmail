using Dmail.Data.Entities.Models;
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
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(new List<User>
                {
                    new User("Lovre", "Tomić")
                    {
                        Id = 1,
                        Email = "tomiclovre05@gmail.com",
                        Password = "pass123"
                    }
                });
        }
    }
}
