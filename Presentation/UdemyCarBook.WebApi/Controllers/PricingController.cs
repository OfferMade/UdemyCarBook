using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.PricingCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.PricingQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetPricingList")]
        public async Task<IActionResult> GetPricingList()
        {
            var results = await _mediator.Send(new GetPricingQueryRequest());
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricingById(int id)
        {
            var result = await _mediator.Send(new GetPricingByIdQueryRequest(id));
            return Ok(result);
        }

        [HttpPost("CreatePricing")]
        public async Task<IActionResult> CreatePricing(CreatePricingCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Pricing created successfully.");
        }

        [HttpPut("UpdatePricing")]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Pricing updated successfully.");
        }

        [HttpDelete("RemovePricing")]
        public async Task<IActionResult> RemovePricing(int id)
        {
            await _mediator.Send(new RemovePricingCommandRequest(id));
            return Ok("Pricing removed successfully.");
        }
    }
}
