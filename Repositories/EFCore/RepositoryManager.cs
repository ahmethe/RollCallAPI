using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<IRollCallRepository> _rollcallRepository;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;

            _customerRepository = new Lazy<ICustomerRepository>(() =>
            new CustomerRepository(context));

            _rollcallRepository = new Lazy<IRollCallRepository>(() =>
            new RollCallRepository(context));
        }

        public ICustomerRepository Customer => _customerRepository.Value;
        public IRollCallRepository RollCall => _rollcallRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
