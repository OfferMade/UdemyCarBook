using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.FeatureCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.FeatureQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("FeatureList")]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _mediator.Send(new GetFeatureQueryRequest());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(int id)
        {
            var value = await _mediator.Send(new GetFeatureByIdQueryRequest(id));
            return Ok(value);
        }

        [HttpPost("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Feature created successfully.");
        }

        [HttpPut("UpdateFeature")]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Feature updated successfully.");
        }

        [HttpDelete("RemoveFeature")]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            await _mediator.Send(new RemoveFeatureCommandRequest(id));
            return Ok("Feature removed successfully.");

        }
    }
}
