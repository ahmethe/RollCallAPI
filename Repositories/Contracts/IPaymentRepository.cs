using Entities.Models;

namespace Repositories.Contracts
{
    public interface IPaymentRepository : IRepositoryBase<Payment>
    {
        void CreateOnePayment(Payment payment);
        void DeleteOnePayment(Payment payment);
        IQueryable<Payment> GetAllPayments(bool trackChanges);
        Payment GetOnePaymentById(int id, bool trackChanges);
        void UpdateOnePayment(Payment payment);
        public IEnumerable<Payment> GetAllPaymentsWithCustomers(bool trackChanges);
    }
}
