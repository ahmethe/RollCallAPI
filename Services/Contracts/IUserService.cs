using Entities.Models;

namespace Services.Contracts
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers(bool trackChanges);
        User GetOneUserById(int id, bool trackChanges);
        User CreateOneUser(User user);
        void UpdateOneUser(int id, User user, bool trackChanges);
        void DeleteOneUser(int id, bool trackChanges);
    }
}
