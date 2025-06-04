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
    public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommandRequest>
    {
        private readonly IRepository<Testimonial> _testimonialRepository;

        public RemoveTestimonialCommandHandler(IRepository<Testimonial> testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task Handle(RemoveTestimonialCommandRequest request, CancellationToken cancellationToken)
        {
            var deletingTestimonial = await _testimonialRepository.GetByIdAsync(request.Id);
            if (deletingTestimonial != null)
            {
                await _testimonialRepository.RemoveAsync(deletingTestimonial);
            }
            else
            {
                throw new Exception("Testimonial not found for deletion.");
            }
        }
    }
}
