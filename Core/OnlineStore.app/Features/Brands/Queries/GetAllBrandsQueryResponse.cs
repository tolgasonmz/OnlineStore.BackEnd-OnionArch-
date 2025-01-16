using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.app.Features.Brands.Queries
{
    public class GetAllBrandsQueryResponse 
    {
        public string name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
