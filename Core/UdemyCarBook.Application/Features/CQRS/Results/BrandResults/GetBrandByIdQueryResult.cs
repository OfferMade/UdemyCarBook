﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Results.BrandResults
{
    public class GetCardByIdQueryResult
    {
        public int BrandID { get; set; }
        public string Name { get; set; }
        
    }
}
