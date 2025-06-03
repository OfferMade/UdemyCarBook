﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Results.LocationResults
{
    public class GetLocationByIdQueryResult
    {
        public int Id { get; set; }

        public GetLocationByIdQueryResult(int id)
        {
            Id = id;
        }
    }
}
