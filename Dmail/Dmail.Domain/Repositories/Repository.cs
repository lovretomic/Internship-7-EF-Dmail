using Dmail.Data.Entities;
using Dmail.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Domain.Repositories
{
    public class Repository
    {
        protected readonly DmailDbContext DbContext;

        protected Repository(DmailDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected ActionStatus SaveChanges()
        {
            var hasChanges = DbContext.SaveChanges() > 0;
            if (hasChanges)
                return ActionStatus.Success;

            return ActionStatus.NoChanges;
        }
    }
}
