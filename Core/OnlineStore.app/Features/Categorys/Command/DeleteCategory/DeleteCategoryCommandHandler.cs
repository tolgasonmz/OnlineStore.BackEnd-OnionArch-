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

namespace OnlineStore.app.Features.Categorys.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : BaseHandler, IRequestHandler<DeleteCategoryCommandRequest, Unit>
    {
        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.GetReadRepository<Category>()
                .GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (category != null)
            {
                category.IsDeleted = true;
                await unitOfWork.GetWriteRepository<Category>()
                    .UpdateAsync(category);
                await unitOfWork.SaveAsync();
            }

            return Unit.Value;
        }
    }
}
