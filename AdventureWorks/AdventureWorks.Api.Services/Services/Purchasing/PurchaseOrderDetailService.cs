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
        public class PurchaseOrderDetailService: AbstractPurchaseOrderDetailService, IPurchaseOrderDetailService
        {
                public PurchaseOrderDetailService(
                        ILogger<PurchaseOrderDetailRepository> logger,
                        IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
                        IApiPurchaseOrderDetailRequestModelValidator purchaseOrderDetailModelValidator,
                        IBOLPurchaseOrderDetailMapper bolpurchaseOrderDetailMapper,
                        IDALPurchaseOrderDetailMapper dalpurchaseOrderDetailMapper)
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
    <Hash>dda343399508f4f8ee7ab23a67a7f2b7</Hash>
</Codenesium>*/