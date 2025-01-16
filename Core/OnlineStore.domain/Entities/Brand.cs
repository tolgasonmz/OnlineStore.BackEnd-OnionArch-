using OnlineStore.domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.domain.Entities
{
    public class Brand : EntityBase
    {
        public Brand() { }
        public Brand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
