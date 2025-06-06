﻿using MediatR;
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
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQueryRequest, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }
        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value != null)
            {
                return new GetServiceByIdQueryResult
                {
                    Description = value.Description,
                    IconUrl = value.IconUrl,
                    ServiceID = value.ServiceID,
                    Title = value.Title
                    

                };
            }
            else
            {
                throw new Exception("Service not found.");
            }
        }
    }
}
