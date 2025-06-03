using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.FooterAddressQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressController : ControllerBase
    {
        private readonly IMediator mediator;

        public FooterAddressController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetFooterAddressList")]
        public async Task<IActionResult> GetFooterAddressList()
        {
            var results = await mediator.Send(new GetFooterAddressQueryRequest());
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddressById(int id)
        {
            var result = await mediator.Send(new GetFooterAddressByIdQueryRequest(id));
            return Ok(result);
        }

        [HttpDelete("RemoveFooterAddress")]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            await mediator.Send(new RemoveFooterAddressCommandRequest(id));
            return Ok("Footer address removed successfully.");
        }

        [HttpPost("CreateFooterAddress")]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommandRequest request)
        {
            await mediator.Send(request);
            return Ok("Footer address created successfully.");
        }

        [HttpPut("UpdateFooterAddress")]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommandRequest request)
        {
            await mediator.Send(request);
            return Ok("Footer address updated successfully.");
        }
    }
}
