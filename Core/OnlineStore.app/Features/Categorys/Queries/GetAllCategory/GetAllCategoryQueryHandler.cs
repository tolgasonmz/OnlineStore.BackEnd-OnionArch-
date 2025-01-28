using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineStore.app.Interfaces.AutoMapper;
using OnlineStore.app.Interfaces.UnitOfWorks;
using OnlineStore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.app.Features.Categorys.Queries.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, IList<GetAllCategoryQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private IMapper mapper;

        public GetAllCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync();
            var map = mapper.Map<GetAllCategoryQueryResponse, Category>(categories);


            return map;
        }
    }
}
