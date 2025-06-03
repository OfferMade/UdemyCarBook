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
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommandRequest>
    {
        private readonly IRepository<Service> repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateServiceCommandRequest request, CancellationToken cancellationToken)
        {
            var updatingService = new Service
            {
                ServiceID = request.ServiceID,
                Title = request.Title,
                Description = request.Description,
                IconUrl = request.IconUrl
            };
            if (updatingService != null)
            {
                await repository.UpdateAsync(updatingService);
            }
            else
            {
                throw new Exception("Service not found");
            }
        }
    }
}
