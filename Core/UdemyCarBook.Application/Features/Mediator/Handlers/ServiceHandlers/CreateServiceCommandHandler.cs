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
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommandRequest>
    {
        private readonly IRepository<Service> _ServiceRepository;

        public CreateServiceCommandHandler(IRepository<Service> ServiceRepository)
        {
            _ServiceRepository = ServiceRepository;
        }

        public async Task Handle(CreateServiceCommandRequest request, CancellationToken cancellationToken)
        {
            var newService = new Service
            {
                Description = request.Description,
                IconUrl = request.IconUrl,
                Title = request.Title


            };
            if (newService != null)
            {
                await _ServiceRepository.CreateAsync(newService);
            }
            else
            {
                throw new Exception("Service cannot be null");
            }
        }
    }
}
