using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.BlogCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommand>
    {
        private readonly IRepository<Blog> repository;

        public RemoveBlogCommandHandler(IRepository<Blog> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var deletingBlog = await repository.GetByIdAsync(request.Id);
            if(deletingBlog != null)
            {
                await repository.RemoveAsync(deletingBlog);
            }
            else
            {
                throw new Exception("Blog not found");
            }
        }
    }
}
