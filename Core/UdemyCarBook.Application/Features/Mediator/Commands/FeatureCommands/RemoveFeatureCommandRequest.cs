using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.FeatureCommands
{
    public class RemoveFeatureCommandRequest: IRequest
    {
        public int Id { get; set; }

        public RemoveFeatureCommandRequest(int id)
        {
            Id = id;
        }
    }
}
