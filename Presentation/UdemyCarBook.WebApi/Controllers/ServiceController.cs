using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.ServiceCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.ServiceQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetServiceList")]
        public async Task<IActionResult> GetServiceList()
        {
            var results = await _mediator.Send(new GetServiceQueryRequest());
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var result = await _mediator.Send(new GetServiceByIdQueryRequest(id));
            return Ok(result);
        }

        [HttpPost("CreateService")]
        public async Task<IActionResult> CreateService(CreateServiceCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Service created successfully.");
        }

        [HttpPut("UpdateService")]
        public async Task<IActionResult> UpdateService(UpdateServiceCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Service updated successfully.");
        }

        [HttpDelete("RemoveService")]
        public async Task<IActionResult> RemoveService(int id)
        {
            await _mediator.Send(new RemoveServiceCommandRequest(id));
            return Ok("Service removed successfully.");
        }
    }
}
