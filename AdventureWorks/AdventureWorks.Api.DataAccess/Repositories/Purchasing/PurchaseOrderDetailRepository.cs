using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class PurchaseOrderDetailRepository : AbstractPurchaseOrderDetailRepository, IPurchaseOrderDetailRepository
        {
                public PurchaseOrderDetailRepository(
                        ILogger<PurchaseOrderDetailRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>df79017b0c2d3d48c8058edf05b620b9</Hash>
</Codenesium>*/