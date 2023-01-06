using Dmail.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Domain.Factories
{
    public static class DbContextFactory
    {
        public static DmailDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseNpgsql(ConfigurationManager.ConnectionStrings["DmailDb"].ConnectionString)
                .Options;

            return new DmailDbContext(options);
        }
    }
}
