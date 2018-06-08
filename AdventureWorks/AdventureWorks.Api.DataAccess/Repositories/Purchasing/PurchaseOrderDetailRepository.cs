using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class PurchaseOrderDetailRepository: AbstractPurchaseOrderDetailRepository, IPurchaseOrderDetailRepository
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
    <Hash>9bf3c98e68f57aee14c7389491842b69</Hash>
</Codenesium>*/