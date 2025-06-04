using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommandRequest>
    {
        private readonly IRepository<Testimonial> _testimonialRepository;

        public CreateTestimonialCommandHandler(IRepository<Testimonial> testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task Handle(CreateTestimonialCommandRequest request, CancellationToken cancellationToken)
        {
            var newTestimonial = new Testimonial
            {
                Name = request.Name,
                Title = request.Title,
                Comment = request.Comment,
                ImageUrl = request.ImageUrl
            };
            if (newTestimonial != null)
            {
                await _testimonialRepository.CreateAsync(newTestimonial);
            }
            else
            {
                throw new Exception("Testimonial creation failed. The testimonial object is null.");
            }
        }
    }
}
