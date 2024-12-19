using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class UserManager : IUserService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;

        public UserManager(IRepositoryManager manager, ILoggerService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        public User CreateOneUser(User user)
        {
            _manager.User.CreateOneUser(user);
            _manager.Save();
            return user;
        }

        public void DeleteOneUser(int id, bool trackChanges)
        {
            var entity = _manager.User.GetOneUserById(id, trackChanges);

            if (entity is null)
                throw new UserNotFoundException(id);
            
            _manager.User.DeleteOneUser(entity);
            _manager.Save();
        }

        public IEnumerable<User> GetAllUsers(bool trackChanges)
        {
            return _manager.User.GetAllUsers(trackChanges);
        }

        public User GetOneUserById(int id, bool trackChanges)
        {
            var user = _manager.User.GetOneUserById(id, trackChanges);

            if (user is null)
                throw new UserNotFoundException(id);

            return user;
        }

        public void UpdateOneUser(int id, User user, bool trackChanges)
        {
            var entity = _manager.User.GetOneUserById(id, trackChanges);
            
            if(entity is null)
                throw new UserNotFoundException(id);

            entity.Email = user.Email;
            entity.Name = user.Name;
            entity.Password = user.Password;

            _manager.User.UpdateOneUser(entity);
            _manager.Save();
        }
    }
}
