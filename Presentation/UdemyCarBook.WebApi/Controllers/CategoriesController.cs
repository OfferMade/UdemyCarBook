using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GetCategoryQueryHandler getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler getCategoryByIdQueryHandler;
        private readonly RemoveCategoryCommandHandler removeCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler updateCategoryCommandHandler;
        private readonly CreateCategoryCommandHandler createCategoryCommandHandler;

        public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, CreateCategoryCommandHandler createCategoryCommandHandler)
        {
            this.getCategoryQueryHandler = getCategoryQueryHandler;
            this.getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            this.removeCategoryCommandHandler = removeCategoryCommandHandler;
            this.updateCategoryCommandHandler = updateCategoryCommandHandler;
            this.createCategoryCommandHandler = createCategoryCommandHandler;
        }

        [HttpGet("CategoryList")]
        public async Task<IActionResult> CategoryList()
        {
            var values = await getCategoryQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value = await getCategoryByIdQueryHandler.Handle(new Application.Features.CQRS.Queries.CategoryQueries.GetCategoryByIdQuery(id));
            return Ok(value);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await createCategoryCommandHandler.Handle(command);
            return Ok("Category oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await updateCategoryCommandHandler.Handle(command);
            return Ok("Category güncellendi");
        }

        [HttpDelete("RemoveCategory")]
        public async Task<IActionResult> RemoveCategory(RemoveCategoryCommand command)
        {
            await removeCategoryCommandHandler.Handle(command);
            return Ok("Category silindi");
        }
    }
}
