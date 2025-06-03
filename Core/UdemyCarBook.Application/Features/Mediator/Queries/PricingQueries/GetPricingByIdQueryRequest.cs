using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.PricingResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingByIdQueryRequest:IRequest<GetPricingByIdQueryResult>
    {
        public int Id { get; set; }
        public GetPricingByIdQueryRequest(int id)
        {
            Id = id;
        }
    }
}
