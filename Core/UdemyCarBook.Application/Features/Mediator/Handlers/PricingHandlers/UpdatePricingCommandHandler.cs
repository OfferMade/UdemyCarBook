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
    public class UpdateServiceCommandHandler : IRequestHandler<UpdatePricingCommandRequest>
    {
        private readonly IRepository<Pricing> repository;

        public UpdateServiceCommandHandler(IRepository<Pricing> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdatePricingCommandRequest request, CancellationToken cancellationToken)
        {
            var updatingPricing = new Pricing
            {
                PricingID = request.PricingID,
                Name = request.Name,
            };
            if (updatingPricing != null)
            {
                await repository.UpdateAsync(updatingPricing);
            }
            else
            {
                throw new Exception("pricing not found");
            }
        }
    }
}
