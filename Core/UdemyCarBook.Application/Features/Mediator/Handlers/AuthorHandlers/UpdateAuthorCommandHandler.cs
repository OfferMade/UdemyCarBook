using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.AuthorCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IRepository<Author> repository;

        public UpdateAuthorCommandHandler(IRepository<Author> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var updatingAuthor = new Author
            {
                AuthorId = request.AuthorId,
                Name = request.Name,
                ImageUrl = request.ImageUrl,
                Description = request.Description
            };
            if(updatingAuthor != null)
            {
                await repository.UpdateAsync(updatingAuthor);
            }
            else
            {
                throw new Exception("Author not found");
            }
        }
    }
}
