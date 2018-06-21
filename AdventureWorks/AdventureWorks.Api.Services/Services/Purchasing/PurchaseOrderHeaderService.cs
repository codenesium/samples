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
        public class PurchaseOrderHeaderService : AbstractPurchaseOrderHeaderService, IPurchaseOrderHeaderService
        {
                public PurchaseOrderHeaderService(
                        ILogger<IPurchaseOrderHeaderRepository> logger,
                        IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
                        IApiPurchaseOrderHeaderRequestModelValidator purchaseOrderHeaderModelValidator,
                        IBOLPurchaseOrderHeaderMapper bolpurchaseOrderHeaderMapper,
                        IDALPurchaseOrderHeaderMapper dalpurchaseOrderHeaderMapper,
                        IBOLPurchaseOrderDetailMapper bolPurchaseOrderDetailMapper,
                        IDALPurchaseOrderDetailMapper dalPurchaseOrderDetailMapper
                        )
                        : base(logger,
                               purchaseOrderHeaderRepository,
                               purchaseOrderHeaderModelValidator,
                               bolpurchaseOrderHeaderMapper,
                               dalpurchaseOrderHeaderMapper,
                               bolPurchaseOrderDetailMapper,
                               dalPurchaseOrderDetailMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>00861b1acd389ca3c9f976e2c0cdafa5</Hash>
</Codenesium>*/