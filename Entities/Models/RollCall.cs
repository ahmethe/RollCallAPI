namespace Entities.Models
{
    public class RollCall
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Customer> Customers { get; } = [];
    }
}
