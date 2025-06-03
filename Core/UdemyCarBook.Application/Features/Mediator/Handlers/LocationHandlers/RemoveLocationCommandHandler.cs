using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.LocationCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommandRequest>
    {
        private readonly IRepository<Location> repository;

        public RemoveLocationCommandHandler(IRepository<Location> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveLocationCommandRequest request, CancellationToken cancellationToken)
        {
            var deletingLocation = await repository.GetByIdAsync(request.Id);
            if(deletingLocation != null)
            {
                await repository.RemoveAsync(deletingLocation);
            }
            else
            {
                throw new Exception("Location not found");
            }
        }
    }
}
