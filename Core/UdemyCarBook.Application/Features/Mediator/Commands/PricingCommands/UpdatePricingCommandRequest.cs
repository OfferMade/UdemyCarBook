﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Commands.PricingCommands
{
    public class UpdatePricingCommandRequest: IRequest
    {
        public int PricingID { get; set; }
        public string Name { get; set; }
        
    }
}
