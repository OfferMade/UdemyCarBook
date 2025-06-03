using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly GetBannerQueryHandler getBannerQueryHandler;
        private readonly GetBannerByIdQueryHandler getBannerByIdQueryHandler;
        private readonly RemoveBannerCommandHandler removeBannerCommandHandler;
        private readonly UpdateBannerCommandHandler updateBannerCommandHandler;
        private readonly CreateBannerCommandHandler createBannerCommandHandler;

        public BannersController(GetBannerQueryHandler getBannerQueryHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler, RemoveBannerCommandHandler removeBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, CreateBannerCommandHandler createBannerCommandHandler)
        {
            this.getBannerQueryHandler = getBannerQueryHandler;
            this.getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            this.removeBannerCommandHandler = removeBannerCommandHandler;
            this.updateBannerCommandHandler = updateBannerCommandHandler;
            this.createBannerCommandHandler = createBannerCommandHandler;
        }

        [HttpGet("BannerList")]
        public async Task<IActionResult> BannerList()
        {
            var values = await getBannerQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var value = await getBannerByIdQueryHandler.Handle(new Application.Features.CQRS.Queries.BannerQueries.GetBannerByIdQuery(id));
            return Ok(value);
        }

        [HttpPost("CreateBanner")]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await createBannerCommandHandler.Handle(command);
            return Ok("banner oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await updateBannerCommandHandler.Handle(command);
            return Ok("banner güncellendi");
        }

        [HttpDelete("RemoveBanner")]
        public async Task<IActionResult> RemoveBanner(RemoveBannerCommand command)
        {
            await removeBannerCommandHandler.Handle(command);
            return Ok("banner silindi");
        }
    }
}
