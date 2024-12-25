using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Surname).IsRequired();

            builder.HasData(
                new Customer()
                {
                    CustomerId = 1,
                    Name = "Ahmet Hilmi",
                    Surname = "Erden"                   
                },
                new Customer()
                {
                    CustomerId = 2,
                    Name = "Selman Emin",
                    Surname = "Erden"
                }
            );
        }
    }
}
