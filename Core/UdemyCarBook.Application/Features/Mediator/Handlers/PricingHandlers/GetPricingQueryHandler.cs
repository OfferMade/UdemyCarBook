using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.PricingQueries;
using UdemyCarBook.Application.Features.Mediator.Results.LocationResults;
using UdemyCarBook.Application.Features.Mediator.Results.PricingResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQueryRequest, List<GetPricingQueryResult>>
    {
        private readonly IRepository<Pricing> _pricingRepository;

        public GetPricingQueryHandler(IRepository<Pricing> pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _pricingRepository.GetAllAsync();
            return values.Select(x => new GetPricingQueryResult
            {
                Name = x.Name,
                PricingID = x.PricingID,
            }).ToList();
        }
    }
}
