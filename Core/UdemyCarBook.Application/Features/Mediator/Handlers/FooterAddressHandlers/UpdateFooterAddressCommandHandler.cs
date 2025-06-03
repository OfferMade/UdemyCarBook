using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommandRequest>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var updatingFooterAddress = await _repository.GetByIdAsync(request.FooterAddressID);
            if(updatingFooterAddress != null)
            {
                updatingFooterAddress.Description = request.Description;
                updatingFooterAddress.Address = request.Address;
                updatingFooterAddress.Phone = request.Phone;
                updatingFooterAddress.Email = request.Email;
                await _repository.UpdateAsync(updatingFooterAddress);
            }
            else
            {
                throw new Exception($"Footer address with ID {request.FooterAddressID} not found.");
            }
        }
    }
}
