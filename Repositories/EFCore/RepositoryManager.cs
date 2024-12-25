using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<IPaymentRepository> _paymentRepository;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;

            _customerRepository = new Lazy<ICustomerRepository>(() =>
            new CustomerRepository(_context));

            _paymentRepository = new Lazy<IPaymentRepository>(() =>
            new PaymentRepository(_context));
        }

        public ICustomerRepository Customer => _customerRepository.Value;

        public IPaymentRepository Payment => _paymentRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
