using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using UdemyCarBook.Application.Features.Mediator.Results.TestimonialResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQueryRequest, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _testimonialRepository;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _testimonialRepository.GetByIdAsync(request.Id);
            if (value == null)
            {
                throw new Exception("Testimonial not found");
            }
            return new GetTestimonialByIdQueryResult
            {
                Comment = value.Comment,
                ImageUrl = value.ImageUrl,
                Name = value.Name,
                TestimonialID = value.TestimonialID,
                Title = value.Title
            };
        }
    }
}
