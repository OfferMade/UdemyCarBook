using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.LocationCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.LocationQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetLocationList")]
        public async Task<IActionResult> GetLocationList()
        {
            var results = await _mediator.Send(new GetLocationQueryRequest());
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var result = await _mediator.Send(new GetLocationByIdQueryRequest(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Location created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Location updated successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            await _mediator.Send(new RemoveLocationCommandRequest(id));
            return Ok("Location removed successfully.");
        }

    }

}