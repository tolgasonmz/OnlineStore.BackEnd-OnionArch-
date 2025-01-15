using Bogus;
using hepsiburada.app.Bases;
using hepsiburada.app.Interfaces.AutoMapper;
using hepsiburada.domain.Entities;
using hepsiburada.app.Interfaces.UnitOfWorks;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;

namespace hepsiburada.app.Features.Brands.Commands.CreateBrand
{
    internal class CreateBrandCommandHandler : BaseHandler, IRequestHandler<CreateBrandCommandRequest, Unit>
    {
        public CreateBrandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Faker faker = new Faker();
            List<Brand> brands = new();

            for (int i = 0; i < 1000000; i++)
            {
                brands.Add(new Brand(faker.Commerce.Department()));
            }

            await unitOfWork.GetWriteRepository<Brand>().AddRangeAsync(brands);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
