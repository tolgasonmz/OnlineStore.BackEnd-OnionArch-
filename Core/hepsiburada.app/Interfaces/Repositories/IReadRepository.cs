using hepsiburada.domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace hepsiburada.app.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : class, IEntityBase , new()
    {
        Task<IList<T>> GetAllASync(Expression<Func<T,bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false);
        Task<IList<T>> GetAllASyncByPaging(Expression<Func<T,bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, 
            bool enableTracking = false, int curentPage = 1, int pageSize = 3);
        Task<T> GetASync(Expression<Func<T, bool>> predicate, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);

        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
