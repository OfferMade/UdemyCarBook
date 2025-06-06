﻿using MediatR;
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
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommandRequest>
    {
        private readonly IRepository<Feature> _repository;

        public UpdateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFeatureCommandRequest request, CancellationToken cancellationToken)
        {
            var updatingFeature = await _repository.GetByIdAsync(request.FeatureID);
            if (updatingFeature != null)
            {
                updatingFeature.Name = request.Name;
                await _repository.UpdateAsync(updatingFeature);
            }
            else
            {
                throw new Exception($"Feature with ID {request.FeatureID} not found.");
            }
        }
    }
}
