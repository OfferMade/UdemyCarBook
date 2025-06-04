using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.TestimonialCommands
{
    public class RemoveTestimonialCommandRequest: IRequest
    {
        public int Id { get; set; }

        public RemoveTestimonialCommandRequest(int id)
        {
            Id = id;
        }
    }
}
