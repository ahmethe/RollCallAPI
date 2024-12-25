namespace Entities.DataTransferObjects
{
    public record PaymentDto
    {
        public DateTime Date { get; init; }
        public string Detail { get; init; }

        public int CustomerId { get; init; }
    }
}
