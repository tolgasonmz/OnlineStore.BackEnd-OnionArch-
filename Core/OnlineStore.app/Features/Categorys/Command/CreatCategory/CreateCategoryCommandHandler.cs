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

namespace OnlineStore.app.Features.Categorys.Command.CreatCategory
{
    public class CreateCategoryCommandHandler : BaseHandler, IRequestHandler<CreateCategoryCommandRequest, Unit>
    {
        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var existingCategory = await unitOfWork.GetReadRepository<Category>().GetAllAsync();

            Category newCategory = new(request.Priorty, request.Name, request.ParentId);

            await unitOfWork.GetWriteRepository<Category>().AddAsync(newCategory);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
