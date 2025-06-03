using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.PricingCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreatePricingCommandRequest>
    {
        private readonly IRepository<Pricing> _pricingRepository;

        public CreateServiceCommandHandler(IRepository<Pricing> pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task Handle(CreatePricingCommandRequest request, CancellationToken cancellationToken)
        {
            var newPricing = new Pricing
            {
                Name = request.Name,


            };
            if (newPricing != null)
            {
                await _pricingRepository.CreateAsync(newPricing);
            }
            else
            {
                throw new Exception("pricing cannot be null");
            }
        }
    }
}
