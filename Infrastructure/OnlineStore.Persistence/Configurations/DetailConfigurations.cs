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
    public class DetailConfigurations : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            //"Bogus" Package install
            Faker faker = new ("tr");

            Detail detail = new()
            {
                Id = 1,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 1,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };
            Detail detail2 = new()
            {
                Id = 2,
                Title = faker.Lorem.Sentence(2),
                Description = faker.Lorem.Sentence(7),
                CategoryId = 3,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };
            Detail detail3 = new()
            {
                Id = 3,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(4),
                CategoryId = 4,
                CreatedDate = DateTime.Now,
                IsDeleted = true,
            };

            builder.HasData(detail,detail2,detail3);
        }
    }
}
