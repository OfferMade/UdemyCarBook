using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Commands.ServiceCommands
{
    public class CreateServiceCommandRequest: IRequest
    {


        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }

    }
}
