using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class SaleTicketsRepository: AbstractSaleTicketsRepository, ISaleTicketsRepository
        {
                public SaleTicketsRepository(
                        ILogger<SaleTicketsRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>6c343bd129d8a990b370270890c014a9</Hash>
</Codenesium>*/