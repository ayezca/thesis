using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Entities
{
    public class RepositoryContextSeed
    {
        private static RepositoryContext _repositoryContext;

        public static async Task SeedAsync(RepositoryContext repositoryContext, ILoggerFactory loggerFactory)
        {
            _repositoryContext = repositoryContext;
            await _repositoryContext.Database.MigrateAsync();
        }
    }
}