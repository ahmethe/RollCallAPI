using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(RepositoryContext repositoryContext) :
            base(repositoryContext)
        {
            
        }

        public void CreateOnePayment(Payment payment) => Create(payment);

        public void DeleteOnePayment(Payment payment) => Delete(payment);

        public IQueryable<Payment> GetAllPayments(bool trackChanges) =>
            FindAll(trackChanges);

        public IEnumerable<Payment> GetAllPaymentsWithCustomers(bool trackChanges)
        {
            return _context
                .Payments
                .Include(c => c.Customer)
                .ToList();
        }
            
        public Payment GetOnePaymentById(int id, bool trackChanges) =>
            FindByCondition(p => p.Id.Equals(id), trackChanges)
            .SingleOrDefault();

        public void UpdateOnePayment(Payment payment) => Update(payment);
    }
}
