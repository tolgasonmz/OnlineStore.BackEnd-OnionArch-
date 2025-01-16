using Bogus;
using OnlineStore.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Persistence.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //"Bogus" Package install
            Faker faker = new ("tr");

            Product product = new()
            {
                Id = 1,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 1,
                Discount = faker.Random.Decimal(0,10),
                Price = faker.Finance.Amount(10,1000),
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };
            Product product2 = new()
            {
                Id = 2,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 4,
                Discount = faker.Random.Decimal(0,10),
                Price = faker.Finance.Amount(10,1000),
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };

            builder.HasData(product,product2);
        }
    }
}
