namespace Entities.DataTransferObjects
{
    public record CustomerDto
    {
        public string Name { get; init; }
        public string Surname { get; init; }
    }
}
