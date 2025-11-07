using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.AuthorCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand>
    {
        private readonly IRepository<Author> repository;

        public RemoveAuthorCommandHandler(IRepository<Author> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var deletingAuthor = await repository.GetByIdAsync(request.Id);
            if(deletingAuthor != null)
            {
                await repository.RemoveAsync(deletingAuthor);
            }
            else
            {
                throw new Exception("Author not found");
            }
        }
    }
}
