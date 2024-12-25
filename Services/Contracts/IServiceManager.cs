namespace Services.Contracts
{
    public interface IServiceManager
    {
        ICustomerService CustomerService { get; }
        IPaymentService PaymentService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}

