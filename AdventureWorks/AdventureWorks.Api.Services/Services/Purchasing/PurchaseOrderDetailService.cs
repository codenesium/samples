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
                               dalpurchaseOrderDetailMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>d0fb65e9989bd2d83b52b2615bcda680</Hash>
</Codenesium>*/