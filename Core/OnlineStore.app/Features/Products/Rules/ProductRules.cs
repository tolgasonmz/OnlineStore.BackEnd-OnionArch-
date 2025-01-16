using OnlineStore.app.Bases;
using OnlineStore.app.Features.Products.Exceptions;
using OnlineStore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.app.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(IList<Product> products, string requestTitle)
        {
            if(products.Any(x=>x.Title == requestTitle))
            {
                throw new ProductTitleMustNotBeSameException();
            }
            return Task.CompletedTask;
        }
    }
}
