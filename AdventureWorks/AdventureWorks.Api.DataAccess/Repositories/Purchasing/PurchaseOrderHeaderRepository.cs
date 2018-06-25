using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class PurchaseOrderHeaderRepository : AbstractPurchaseOrderHeaderRepository, IPurchaseOrderHeaderRepository
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
    <Hash>fd855690894d96347c6d896e6da2e045</Hash>
</Codenesium>*/