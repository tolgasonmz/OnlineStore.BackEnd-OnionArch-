using hepsiburada.domain.Common;
using hepsiburada.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hepsiburada.domain.Entities
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
        public int ParentId { get; set; }
        public int Priorty{ get; set; }
        public string Name { get; set; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<ProductCategory> ProductCategory { get; set; }
    }
}