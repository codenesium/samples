using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class PurchaseOrderHeaderService: AbstractPurchaseOrderHeaderService, IPurchaseOrderHeaderService
        {
                public PurchaseOrderHeaderService(
                        ILogger<PurchaseOrderHeaderRepository> logger,
                        IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
                        IApiPurchaseOrderHeaderRequestModelValidator purchaseOrderHeaderModelValidator,
                        IBOLPurchaseOrderHeaderMapper bolpurchaseOrderHeaderMapper,
                        IDALPurchaseOrderHeaderMapper dalpurchaseOrderHeaderMapper)
                        : base(logger,
                               purchaseOrderHeaderRepository,
                               purchaseOrderHeaderModelValidator,
                               bolpurchaseOrderHeaderMapper,
                               dalpurchaseOrderHeaderMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>55a734263529d4edfd7e090e4dc9a910</Hash>
</Codenesium>*/