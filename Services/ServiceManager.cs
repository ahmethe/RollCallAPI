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
        private readonly Lazy<IPaymentService> _paymentService;
        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerService logger,
            IMapper mapper,
            IConfiguration configuration,
            UserManager<User> userManager)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationManager(logger, mapper, userManager, configuration));

            _customerService = new Lazy<ICustomerService>(() =>
            new CustomerManager(repositoryManager, mapper));
            
            _paymentService = new Lazy<IPaymentService>(() =>
            new PaymentManager(repositoryManager, mapper, CustomerService));
        }

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public ICustomerService CustomerService => _customerService.Value;
        public IPaymentService PaymentService => _paymentService.Value;
    }
}
