namespace Entities.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Detail { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
