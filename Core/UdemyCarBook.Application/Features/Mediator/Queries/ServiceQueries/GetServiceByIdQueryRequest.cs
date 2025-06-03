using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.ServiceResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceByIdQueryRequest:IRequest<GetServiceByIdQueryResult>
    {
        public int Id { get; set; }
        public GetServiceByIdQueryRequest(int id)
        {
            Id = id;
        }
    }
}
