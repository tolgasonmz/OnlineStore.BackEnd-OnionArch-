using OnlineStore.app.Features.Brands.Commands.CreateBrand;
using OnlineStore.app.Features.Products.Command.CreateProduct;
using OnlineStore.app.Features.Products.Command.DeleteProduct;
using OnlineStore.app.Features.Products.Command.UpdateProduct;
using OnlineStore.app.Features.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await mediator.Send(new GetAllProductsQueryRequest());
            return Ok(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateProducts(CreateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        } 
        
        [HttpPost]
        public async Task<IActionResult> UpdateProducts(UpdateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteProducts(DeleteProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
