using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public partial class SaleRepository : AbstractSaleRepository, ISaleRepository
        {
                public SaleRepository(
                        ILogger<SaleRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>b55f87edea2ff3309aaedd348a0ada35</Hash>
</Codenesium>*/