using MediatR;
using Microsoft.AspNetCore.Http;
using OnlineStore.app.Bases;
using OnlineStore.app.Interfaces.AutoMapper;
using OnlineStore.app.Interfaces.UnitOfWorks;
using OnlineStore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.app.Features.Categorys.Command.UpdateCategory
{
    public class UpdateCategoryCommandHandler : BaseHandler, IRequestHandler<UpdateCategoryCommandRequest,Unit>
    {
        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.GetReadRepository<Category>()
                .GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            var map = mapper.Map<Category, UpdateCategoryCommandRequest>(request);

            await unitOfWork.GetWriteRepository<Category>()
                .UpdateAsync(map);

            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
