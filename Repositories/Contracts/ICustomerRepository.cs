using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        void CreateOneCustomer(Customer customer);
        void DeleteOneCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomers(bool trackChanges);
        Customer GetOneCustomerById(int id, bool trackChanges);
        void UpdateOneCustomer(Customer customer);
    }
}
