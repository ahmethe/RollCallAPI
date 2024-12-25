using Entities.Models;
using Services.Contracts;
using Repositories.Contracts;
using Entities.Exceptions;
using AutoMapper;
using Entities.DataTransferObjects;

namespace Services
{
    public class CustomerManager : ICustomerService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CustomerManager(IRepositoryManager manager, 
            IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IEnumerable<Customer> GetAllCustomers(bool trackChanges)
        {
            var customers = _manager.Customer.GetAllCustomers(trackChanges);

            return customers;
        }

        public CustomerDto GetCustomerById(int id, bool trackChanges)
        {
            var customer = GetOneCustomerAndCheckExists(id, trackChanges);

            return _mapper.Map<CustomerDto>(customer);
        }

        public CustomerDto AddCustomer(CustomerDto customerDto)
        {
            var entity = _mapper.Map<Customer>(customerDto);
            _manager.Customer.CreateOneCustomer(entity);
            _manager.Save();

            return _mapper.Map<CustomerDto>(entity);
        }

        public void UpdateCustomer(int id,
            CustomerDtoForUpdate customerDto,
            bool trackChanges)
        {
            var entity = GetOneCustomerAndCheckExists(id, false);

            entity = _mapper.Map<Customer>(customerDto);

            _manager.Customer.UpdateOneCustomer(entity);
            _manager.Save();
        }

        public void DeleteCustomer(int id, bool trackChanges)
        {
            var entity = GetOneCustomerAndCheckExists(id, trackChanges);

            _manager.Customer.DeleteOneCustomer(entity);
            _manager.Save();
        }

        private Customer GetOneCustomerAndCheckExists(int id, bool trackChanges)
        {
            var customer = _manager.Customer.GetOneCustomerById(id, trackChanges);

            if (customer is null)
                throw new CustomerNotFoundException(id);

            return customer;
        }
    }
}
