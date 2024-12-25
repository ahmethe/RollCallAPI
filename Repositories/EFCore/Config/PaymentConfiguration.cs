using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasData(
                new Payment { Id = 1, CustomerId = 1, Date = DateTime.Now, Detail = "1000 TL okul ücreti."},
                new Payment { Id = 2, CustomerId = 2, Date = DateTime.Now, Detail = "200 TL Ekipman ücreti." },
                new Payment { Id = 3, CustomerId = 2, Date = DateTime.Now, Detail = "1500 TL okul ücreti." }
            );
        }
    }
}
