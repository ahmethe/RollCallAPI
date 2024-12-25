namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ICustomerRepository Customer { get; }
        IPaymentRepository Payment { get; }
        void Save();
    }
}
