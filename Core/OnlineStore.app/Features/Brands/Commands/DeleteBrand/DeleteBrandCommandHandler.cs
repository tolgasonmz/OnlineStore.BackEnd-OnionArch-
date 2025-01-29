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

namespace OnlineStore.app.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandHandler : BaseHandler,IRequestHandler<DeleteBrandCommandRequest, Unit>
    {
        public DeleteBrandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
        {
            var brand = await unitOfWork.GetReadRepository<Brand>()
                .GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (brand != null)
            {
                brand.IsDeleted = true;
                await unitOfWork.GetWriteRepository<Brand>()
                    .UpdateAsync(brand);
                await unitOfWork.SaveAsync();
            }
            return Unit.Value;
        }
    }
}
