using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<ICustomerRepository> _customerRepository;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;

            _customerRepository = new Lazy<ICustomerRepository>(() =>
            new CustomerRepository(context));
        }

        public ICustomerRepository Customer => _customerRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
