using System.Xml.Serialization;

namespace BeeBuzz.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        private ApplicationDbContext _context;
        private readonly IRepositoryProvider _repositoryProvider;
        //private ILogger<DutchProductRepository> _loggerProduct;
        //private DutchProductRepository _productRepository;

        public UnitOfWork(ApplicationDbContext context, IRepositoryProvider provider, ILoggerFactory loggerFactory) 
        {
            //_loggerOrder = new Logger<DutchOrderRepository>(loggerFactory);
            //_loggerProduct = new Logger<DutchProductRepository>(loggerFactory);
            _context = context;
            _repositoryProvider = provider;
        }

        public T GetRepository<T>() where T : class
        {
            return _repositoryProvider.GetRepository<T>();
        }
        
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        
    }
}
