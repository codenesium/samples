using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public partial class SaleTicketsRepository : AbstractSaleTicketsRepository, ISaleTicketsRepository
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
    <Hash>64431e5af94f455a9550ec36a6fff270</Hash>
</Codenesium>*/