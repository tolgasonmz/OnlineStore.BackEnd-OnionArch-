using OnlineStore.app.Bases;
using OnlineStore.app.Interfaces.AutoMapper;
using OnlineStore.app.Interfaces.UnitOfWorks;
using OnlineStore.domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.app.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : BaseHandler, IRequestHandler<DeleteProductCommandRequest, Unit>
    {

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>()
                .GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            if (product != null)
            {
                product.IsDeleted = true;

                await unitOfWork.GetWriteRepository<Product>()
                    .UpdateAsync(product);
                await unitOfWork.SaveAsync();
            }

            return Unit.Value;
        }
    }
}
