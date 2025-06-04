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
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQueryRequest, List<GetTestimonialQueryResult>>
    {
        private readonly IRepository<Testimonial> repository;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            this.repository = repository;
        }

        async Task<List<GetTestimonialQueryResult>> IRequestHandler<GetTestimonialQueryRequest, List<GetTestimonialQueryResult>>.Handle(GetTestimonialQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();
            return values.Select(x=> new GetTestimonialQueryResult
            {
                TestimonialID = x.TestimonialID,
                Name = x.Name,
                Title = x.Title,
                Comment = x.Comment,
                ImageUrl = x.ImageUrl
            }).ToList();
        }
    }
}
