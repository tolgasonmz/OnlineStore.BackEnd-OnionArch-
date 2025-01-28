using Bogus;
using OnlineStore.app.Bases;
using OnlineStore.app.Interfaces.AutoMapper;
using OnlineStore.domain.Entities;
using OnlineStore.app.Interfaces.UnitOfWorks;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;

namespace OnlineStore.app.Features.Brands.Commands.CreateBrand
{
    internal class CreateBrandCommandHandler : BaseHandler, IRequestHandler<CreateBrandCommandRequest, Unit>
    {
        public CreateBrandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {

            //Faker faker = new Faker();
            //for (int i = 0; i < 1000000; i++)
            //{
            //    brands.Add(new Brand(faker.Commerce.Department()));
            //}

            List<Brand> brands = new();

            await unitOfWork.GetWriteRepository<Brand>().AddRangeAsync(brands);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
