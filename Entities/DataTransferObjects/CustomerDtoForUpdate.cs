namespace Entities.DataTransferObjects
{
    public record CustomerDtoForUpdate
    {
        public int CustomerId { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
    }
}
