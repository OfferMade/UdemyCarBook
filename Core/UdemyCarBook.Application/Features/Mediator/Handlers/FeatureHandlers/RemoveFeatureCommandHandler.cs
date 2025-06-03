using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.FeatureCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommandRequest>
    {
        private readonly IRepository<Feature> _repository;

        public RemoveFeatureCommandHandler(IRepository<Feature> repository )
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFeatureCommandRequest request, CancellationToken cancellationToken)
        {
            var deletingFeature = await _repository.GetByIdAsync(request.Id);
            if (deletingFeature != null)
            {
                await _repository.RemoveAsync(deletingFeature);
            }
            else
            {
                throw new Exception($"Feature with ID {request.Id} not found.");
            }
            
        }
    }
}
