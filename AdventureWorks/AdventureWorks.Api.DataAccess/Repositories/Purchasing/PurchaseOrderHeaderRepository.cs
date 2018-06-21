using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class PurchaseOrderHeaderRepository : AbstractPurchaseOrderHeaderRepository, IPurchaseOrderHeaderRepository
        {
                public PurchaseOrderHeaderRepository(
                        ILogger<PurchaseOrderHeaderRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>5bf5f01e938965ebe2636d971abe5220</Hash>
</Codenesium>*/