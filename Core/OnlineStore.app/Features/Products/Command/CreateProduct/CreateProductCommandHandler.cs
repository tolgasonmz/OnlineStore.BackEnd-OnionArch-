using OnlineStore.app.Bases;
using OnlineStore.app.Features.Products.Rules;
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

namespace OnlineStore.app.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : BaseHandler, IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly ProductRules productsRules;

        public CreateProductCommandHandler(ProductRules productRules,IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.productsRules = productRules;
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
           IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();

            await productsRules.ProductTitleMustNotBeSame(products, request.Title);


            Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);

            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);

            if (await unitOfWork.SaveAsync() > 0)
            {
                foreach (var categoryId in request.CategoryIds)
                {
                    await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId
                    });
                }
                await unitOfWork.SaveAsync();
            }

            return Unit.Value;
        }
    }
}
