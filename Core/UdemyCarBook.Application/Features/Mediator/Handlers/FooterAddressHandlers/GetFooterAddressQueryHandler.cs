using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FooterAddressResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQueryRequest, List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQueryRequest request, CancellationToken cancellationToken)
        {
            var footerAddresses = await _repository.GetAllAsync();
            return footerAddresses.Select(footerAddresses => new GetFooterAddressQueryResult
            {
                FooterAddressID = footerAddresses.FooterAddressID,
                Address = footerAddresses.Address,
                Description = footerAddresses.Description,
                Email = footerAddresses.Email,
                Phone = footerAddresses.Phone,
            }).ToList();
        }
    }
}
