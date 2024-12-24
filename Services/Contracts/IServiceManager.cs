namespace Services.Contracts
{
    public interface IServiceManager
    {
        ICustomerService CustomerService { get; }
        IRollCallService RollCallService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}

