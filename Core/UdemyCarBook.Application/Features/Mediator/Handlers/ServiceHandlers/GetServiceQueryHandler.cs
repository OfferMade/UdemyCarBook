using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.ServiceQueries;
using UdemyCarBook.Application.Features.Mediator.Results.LocationResults;
using UdemyCarBook.Application.Features.Mediator.Results.ServiceResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQueryRequest, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _ServiceRepository;

        public GetServiceQueryHandler(IRepository<Service> ServiceRepository)
        {
            _ServiceRepository = ServiceRepository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _ServiceRepository.GetAllAsync();
            return values.Select(x => new GetServiceQueryResult
            {
                Description = x.Description,
                Title = x.Title,
                ServiceID = x.ServiceID,
                IconUrl = x.IconUrl
            }).ToList();
        }
    }
}
