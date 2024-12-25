using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record PaymentDtoForManipulation
    {
        public int Id { get; init; }
        public DateTime Date { get; init; }
        public string Detail { get; init; }
        public int CustomerId { get; init; }
    }
}
