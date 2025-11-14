
using BeeBuzz.Data.Interfaces;

namespace BeeBuzz.Data.Repositories.Helpers
{
    public class RepositoryFactories
    {
        private ILoggerFactory _loggerFactory;
        private readonly IDictionary<Type, Func<ApplicationDbContext, object>> _repositoryFactories;

        private IDictionary<Type, Func<ApplicationDbContext, object>> GetDucthFactories()
        {
            return new Dictionary<Type, Func<ApplicationDbContext, object>>
            {
            };
        }
        public RepositoryFactories(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _repositoryFactories = GetDucthFactories();
        }

        public Func<ApplicationDbContext, object> GetRepositoryFactory<T>()
        {
            Func<ApplicationDbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        public Func<ApplicationDbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        protected virtual Func<ApplicationDbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            return dbContext => new BeeBuzzGenericRepository<T>(dbContext);
        }


    }
}
