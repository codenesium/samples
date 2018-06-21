using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class SaleTicketsRepository : AbstractSaleTicketsRepository, ISaleTicketsRepository
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
    <Hash>9e932f0e7df48e11824d6097969de7bd</Hash>
</Codenesium>*/