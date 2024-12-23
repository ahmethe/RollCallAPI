using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerService logger,
            IMapper mapper,
            IConfiguration configuration,
            UserManager<User> userManager) 
        {
            _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationManager(logger, mapper, userManager, configuration));
        }

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
