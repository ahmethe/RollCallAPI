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
        private readonly Lazy<ICustomerService> _customerService;
        private readonly Lazy<IRollCallService> _rollcallService;
        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerService logger,
            IMapper mapper,
            IConfiguration configuration,
            UserManager<User> userManager) 
        {
            _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationManager(logger, mapper, userManager, configuration));

            _customerService = new Lazy<ICustomerService>(() =>
            new CustomerManager(repositoryManager));

            _rollcallService = new Lazy<IRollCallService>(() =>
            new RollCallManager(repositoryManager));
        }

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public ICustomerService CustomerService => _customerService.Value;
        public IRollCallService RollCallService => _rollcallService.Value;

    }
}
