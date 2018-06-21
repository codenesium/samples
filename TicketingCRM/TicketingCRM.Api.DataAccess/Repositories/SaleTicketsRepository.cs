using Codenesium.DataConversionExtensions;
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
    <Hash>4f51c7e12492e1bc3d1e1f1896c09c8e</Hash>
</Codenesium>*/