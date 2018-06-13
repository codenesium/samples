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
                        IDALPurchaseOrderDetailMapper dalpurchaseOrderDetailMapper

                        )
                        : base(logger,
                               purchaseOrderDetailRepository,
                               purchaseOrderDetailModelValidator,
                               bolpurchaseOrderDetailMapper,
                               dalpurchaseOrderDetailMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>1e0bb4f3e1aca48d15a2ef4d36914f61</Hash>
</Codenesium>*/