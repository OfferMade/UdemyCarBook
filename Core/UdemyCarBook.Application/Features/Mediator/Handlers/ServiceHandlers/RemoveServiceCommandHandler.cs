using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.ServiceCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommandRequest>
    {
        private readonly IRepository<Service> repository;

        public RemoveServiceCommandHandler(IRepository<Service> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveServiceCommandRequest request, CancellationToken cancellationToken)
        {
            var deletingService = await repository.GetByIdAsync(request.Id);
            if (deletingService != null)
            {
                await repository.RemoveAsync(deletingService);
            }
            else
            {
                throw new Exception("Service not found");
            }
        }
    }
}
