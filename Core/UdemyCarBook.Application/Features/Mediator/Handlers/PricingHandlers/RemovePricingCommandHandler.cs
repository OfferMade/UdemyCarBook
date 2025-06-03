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
    public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommandRequest>
    {
        private readonly IRepository<Pricing> repository;

        public RemovePricingCommandHandler(IRepository<Pricing> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemovePricingCommandRequest request, CancellationToken cancellationToken)
        {
            var deletingPricing = await repository.GetByIdAsync(request.Id);
            if (deletingPricing != null)
            {
                await repository.RemoveAsync(deletingPricing);
            }
            else
            {
                throw new Exception("pricing not found");
            }
        }
    }
}
