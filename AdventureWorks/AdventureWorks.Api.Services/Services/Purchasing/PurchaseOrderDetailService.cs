using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class PurchaseOrderDetailService : AbstractPurchaseOrderDetailService, IPurchaseOrderDetailService
        {
                public PurchaseOrderDetailService(
                        ILogger<IPurchaseOrderDetailRepository> logger,
                        IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
                        IApiPurchaseOrderDetailRequestModelValidator purchaseOrderDetailModelValidator,
                        IBOLPurchaseOrderDetailMapper bolpurchaseOrderDetailMapper,
                        IDALPurchaseOrderDetailMapper dalpurchaseOrderDetailMapper
                        )
                        : base(logger,
                               purchaseOrderDetailRepository,
                               purchaseOrderDetailModelValidator,
                               bolpurchaseOrderDetailMapper,
                               dalpurchaseOrderDetailMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e1f20c54ca703f4108a37931df152e64</Hash>
</Codenesium>*/