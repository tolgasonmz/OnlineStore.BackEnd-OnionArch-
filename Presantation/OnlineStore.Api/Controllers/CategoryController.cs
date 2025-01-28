using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.app.Features.Categorys.Command.CreatCategory;
using OnlineStore.app.Features.Categorys.Command.DeleteCategory;
using OnlineStore.app.Features.Categorys.Command.UpdateCategory;
using OnlineStore.app.Features.Categorys.Queries.GetAllCategory;

namespace OnlineStore.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;
        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await mediator.Send(new GetAllCategoryQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
