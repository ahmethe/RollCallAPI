using Entities.DataTransferObjects;
using Entities.Models;

namespace Services.Contracts
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers(bool trackChanges);
        CustomerDto GetCustomerById(int id, bool trackChanges);
        CustomerDto AddCustomer(CustomerDto customerDto);
        void UpdateCustomer(int id, CustomerDtoForUpdate customerDto, bool trackChanges);
        void DeleteCustomer(int id, bool trackChanges);
    }
}
