namespace Entities.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Payment> Payments { get; } = [];
        public ICollection<RollCall> RollCalls { get; set; } = [];
    }
}
