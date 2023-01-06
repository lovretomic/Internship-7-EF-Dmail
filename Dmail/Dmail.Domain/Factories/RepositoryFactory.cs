using Dmail.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Domain.Factories
{
    public class RepositoryFactory
    {
        public static TRepository Create<TRepository>()
        where TRepository : Repository
        {
            var dbContext = DbContextFactory.GetDbContext();
            var repositoryInstance = Activator.CreateInstance(typeof(TRepository), dbContext) as TRepository;

            return repositoryInstance!;
        }
    }
}
