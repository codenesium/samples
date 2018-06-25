using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class PurchaseOrderDetailRepository : AbstractPurchaseOrderDetailRepository, IPurchaseOrderDetailRepository
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
    <Hash>fc0c8fb58fb2ef6e9c80f319b0410eb2</Hash>
</Codenesium>*/