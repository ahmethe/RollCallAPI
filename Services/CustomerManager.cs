using Entities.Models;
using Services.Contracts;
using Repositories.Contracts;

namespace Services
{
    public class CustomerManager : ICustomerService
    {
        private readonly IRepositoryManager _manager;

        public CustomerManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Customer> GetAllCustomers(bool trackChanges)
        {
            return _manager.Customer.GetAllCustomers(trackChanges);
        }

        public Customer GetCustomerById(int id, bool trackChanges)
        {
            var customer = _manager.Customer.GetOneCustomerById(id, trackChanges);

            if (customer is null)
                throw new Exception(); //

            return customer;
        }

        public Customer AddCustomer(Customer customer)
        {
            _manager.Customer.CreateOneCustomer(customer);
            _manager.Save();

            return customer;
        }

        public void UpdateCustomer(int id,
            Customer customer,
            bool trackChanges)
        {
            var entity = _manager.Customer.GetOneCustomerById(id, trackChanges);
            
            if(entity is null)
                throw new Exception(); //

            //

            _manager.Customer.UpdateOneCustomer(customer);
            _manager.Save();
        }

        public void DeleteCustomer(int id, bool trackChanges)
        {
            var entity = _manager.Customer.GetOneCustomerById(id, trackChanges);

            if (entity is null)
                throw new Exception(); //

            _manager.Customer.DeleteOneCustomer(entity);
            _manager.Save();
        }
    }
}
