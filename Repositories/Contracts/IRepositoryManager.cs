namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ICustomerRepository Customer { get; }

        IRollCallRepository RollCall { get; }
        void Save();
    }
}
