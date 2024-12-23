using Entities.Models;

namespace Services.Contracts
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers(bool trackChanges);
        Customer GetCustomerById(int id, bool trackChanges);
        Customer AddCustomer(Customer customer);
        void UpdateCustomer(int id, Customer customer, bool trackChanges);
        void DeleteCustomer(int id, bool trackChanges);
    }
}
