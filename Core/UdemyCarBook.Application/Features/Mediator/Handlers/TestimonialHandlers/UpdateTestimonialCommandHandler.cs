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
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommandRequest>
    {
        private readonly IRepository<Testimonial> repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommandRequest request, CancellationToken cancellationToken)
        {
            var updatingTestimonial = new Testimonial
            {
                TestimonialID = request.TestimonialID,
                Name = request.Name,
                Title = request.Title,
                Comment = request.Comment,
                ImageUrl = request.ImageUrl
            };
            await repository.UpdateAsync(updatingTestimonial);
        }
    }
}
