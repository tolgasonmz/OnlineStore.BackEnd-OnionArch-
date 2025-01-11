﻿using hepsiburada.domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hepsiburada.domain.Entities
{
    public class ProductCategory : IEntityBase
    {
        public int ProductId{ get; set; }
        public int CategoryId{ get; set; }
        public Product Product{ get; set; }
        public Category Category{ get; set; }
    }
}
