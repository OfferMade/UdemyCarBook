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
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommandRequest>
    {
        private readonly IRepository<Location> repository;

        public CreateLocationCommandHandler(IRepository<Location> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateLocationCommandRequest request, CancellationToken cancellationToken)
        {
            var newLocation = new Location
            {
                Name = request.Name,

            };
            if(newLocation != null)
            {
                await repository.CreateAsync(newLocation);
            }
            else
            {
                throw new Exception("Location cannot be null");
            }
        }
    }
}
