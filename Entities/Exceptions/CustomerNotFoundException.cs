namespace Entities.Exceptions
{
    public sealed class CustomerNotFoundException : NotFoundException
    {
        public CustomerNotFoundException(int id)
            : base($"Customer with id: {id} could not found.")
        {
            
        }
    }
}
