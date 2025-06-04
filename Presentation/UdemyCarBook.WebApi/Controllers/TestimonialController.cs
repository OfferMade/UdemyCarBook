using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.TestimonialQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetTestimonialList")]
        public async Task<IActionResult> GetTestimonialList()
        {
            var results = await _mediator.Send(new GetTestimonialQueryRequest());
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonialById(int id)
        {
            var result = await _mediator.Send(new GetTestimonialByIdQueryRequest(id));
            return Ok(result);
        }

        [HttpPost("CreateTestimonial")]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Testimonial created successfully.");
        }

        [HttpPut("UpdateTestimonial")]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Testimonial updated successfully.");
        }

        [HttpDelete("RemoveTestimonial")]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            await _mediator.Send(new RemoveTestimonialCommandRequest(id));
            return Ok("Testimonial removed successfully.");
        }
    }
}
