using Entities.Models;
using System.Linq.Expressions;

namespace Repositories.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IQueryable<User> GetAllUsers(bool trackChanges);
        User GetOneUserById(int id, bool trackChanges);
        void CreateOneUser(User entity);
        void UpdateOneUser(User entity);
        void DeleteOneUser(User entity);
    }
}
