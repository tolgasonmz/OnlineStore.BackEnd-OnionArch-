using MediatR;
using OnlineStore.app.Interfaces.RedisCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.app.Features.Categorys.Queries.GetAllCategory
{
    public class GetAllCategoryQueryRequest : IRequest<IList<GetAllCategoryQueryResponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllCategoryQueryRequest";
        public double CacheTime => 60;
    }
}
