﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.ServiceCommands
{
    public class RemoveServiceCommandRequest: IRequest
    {
        public int Id { get; set; }
        public RemoveServiceCommandRequest(int id)
        {
            Id = id;
        }
    }
}
