using Entities.DataTransferObjects;
using Entities.Models;

namespace Services.Contracts
{
    public interface IPaymentService
    {
        IEnumerable<Payment> GetAllPayments(bool trackChanges);
        PaymentDto GetPaymentById(int id, bool trackChanges);
        PaymentDto AddPayment(PaymentDtoForManipulation paymentDto);
        void UpdatePayment(int id, PaymentDtoForManipulation paymentDto, bool trackChanges);
        void DeletePayment(int id, bool trackChanges);
        IEnumerable<Payment> GetAllPaymentsWithCustomers(bool trackChanges);
    }
}
