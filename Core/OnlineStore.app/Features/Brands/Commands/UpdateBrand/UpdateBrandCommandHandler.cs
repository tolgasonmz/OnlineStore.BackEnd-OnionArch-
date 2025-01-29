using MediatR;
using Microsoft.AspNetCore.Http;
using OnlineStore.app.Bases;
using OnlineStore.app.Features.Categorys.Command.UpdateCategory;
using OnlineStore.app.Interfaces.AutoMapper;
using OnlineStore.app.Interfaces.UnitOfWorks;
using OnlineStore.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.app.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandHandler : BaseHandler, IRequestHandler<UpdateBrandCommandRequest, Unit>
    {
        public UpdateBrandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }
        public async Task<Unit> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var brand = await unitOfWork.GetReadRepository<Brand>()
                .GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            var map = mapper.Map<Brand, UpdateBrandCommandRequest>(request);

            await unitOfWork.GetWriteRepository<Brand>()
                .UpdateAsync(map);

            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
