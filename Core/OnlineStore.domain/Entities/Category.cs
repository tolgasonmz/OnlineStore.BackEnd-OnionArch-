using OnlineStore.domain.Common;
using OnlineStore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.domain.Entities
{
    public class Category : EntityBase
    {
        public Category() { }

        public Category(int parentId, string name, int priorty)
        {
            ParentId = parentId;
            Name = name;
            Priorty = priorty;
        }

        public int Id { get; set; }
        public int ParentId { get; set; }
        public int Priorty{ get; set; }
        public string Name { get; set; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
