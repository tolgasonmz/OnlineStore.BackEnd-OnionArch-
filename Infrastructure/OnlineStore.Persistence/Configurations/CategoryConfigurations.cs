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
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //"Bogus" Package install
            Category category1 = new()
            {
                Id = 1,
                Name = "Elektrik",
                Priorty = 1,
                ParentId = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };
            Category category2 = new()
            {
                Id = 2,
                Name = "Moda",
                Priorty = 2,
                ParentId = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };
            Category parent1 = new()
            {
                Id = 3,
                Name = "Bilgisayar",
                Priorty = 2,
                ParentId = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };
            Category parent2 = new()
            {
                Id = 4,
                Name = "Kadýn",
                Priorty = 2,
                ParentId = 2,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };

            builder.HasData(parent1, parent2, category1,category2);
        }
    }
}
