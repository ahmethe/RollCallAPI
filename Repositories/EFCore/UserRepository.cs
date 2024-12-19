using Entities.Models;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.EFCore
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneUser(User user) => Create(user);

        public void DeleteOneUser(User user) => Delete(user);

        public IQueryable<User> GetAllUsers(bool trackChanges) => 
            FindAll(trackChanges);

        public User GetOneUserById(int id, bool trackChanges) => 
            FindByCondition(u => u.Id.Equals(id), trackChanges)
            .SingleOrDefault();

        public void UpdateOneUser(User user) => Update(user);
    }
}
