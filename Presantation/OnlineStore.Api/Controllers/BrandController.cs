using OnlineStore.app.Features.Brands.Commands.CreateBrand;
using OnlineStore.app.Features.Brands.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.app.Features.Brands.Commands.UpdateBrand;
using OnlineStore.app.Features.Brands.Commands.DeleteBrand;

namespace OnlineStore.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator mediator;
        public BrandController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var response = await mediator.Send(new GetAllBrandsQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBrand(DeleteBrandCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
