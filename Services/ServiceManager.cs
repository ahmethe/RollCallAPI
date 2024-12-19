using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> userService;
        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerService logger) 
        {
            userService = new Lazy<IUserService>(() => new UserManager(repositoryManager, logger));
        }
        public IUserService UserService => userService.Value;
    }
}
