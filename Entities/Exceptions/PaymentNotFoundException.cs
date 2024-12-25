namespace Entities.Exceptions
{
    public sealed class PaymentNotFoundException : NotFoundException
    {
        public PaymentNotFoundException(int id)
            : base($"Payment with id: {id} could not found.")
        {
            
        }
    }
}
