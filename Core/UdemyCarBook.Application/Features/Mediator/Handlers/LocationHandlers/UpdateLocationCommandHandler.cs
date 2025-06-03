using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.LocationCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommandRequest>
    {
        private readonly IRepository<Location> repository;

        public UpdateLocationCommandHandler(IRepository<Location> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateLocationCommandRequest request, CancellationToken cancellationToken)
        {
            var updatingLocation = new Location
            {
                LocationID = request.LocationID,
                Name = request.Name,
            };
            if(updatingLocation != null)
            {
                await repository.UpdateAsync(updatingLocation);
            }
            else
            {
                throw new Exception("Location not found");
            }
        }
    }
}
