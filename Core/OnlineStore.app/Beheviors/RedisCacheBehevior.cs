using OnlineStore.app.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.app.Beheviors
{
    public class RedisCacheBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IRedisCacheService redisCacheService;

        public RedisCacheBehevior(IRedisCacheService redisCacheService)
        {
            this.redisCacheService = redisCacheService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(request is ICacheableQuery query)
            {
                var cacheKey = query.CacheKey;
                var cacheTime = query.CacheTime;
                var cachedResponse = await redisCacheService.GetAsync<TResponse>(cacheKey);
                if (cachedResponse != null)
                {
                    return cachedResponse;
                }
                var response = await next();
                if (response != null)
                {
                    await redisCacheService.SetAsync(cacheKey, response, DateTime.Now.AddMinutes(cacheTime));
                }
                return response;
            }

            return await next();
        }
    }
}
