using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateOneCustomer(Customer customer) => Create(customer);

        public void DeleteOneCustomer(Customer customer) => Delete(customer);

        public IEnumerable<Customer> GetAllCustomers(bool trackChanges) =>
            FindAll(trackChanges);

        public Customer GetOneCustomerById(int id, bool trackChanges) =>
            FindByCondition(c => c.CustomerId.Equals(id), trackChanges)
            .SingleOrDefault();

        public void UpdateOneCustomer(Customer customer) => Update(customer);
    }
}
