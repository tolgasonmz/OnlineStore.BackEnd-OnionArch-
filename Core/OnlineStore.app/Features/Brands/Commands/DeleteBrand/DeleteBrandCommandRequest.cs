﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.app.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
