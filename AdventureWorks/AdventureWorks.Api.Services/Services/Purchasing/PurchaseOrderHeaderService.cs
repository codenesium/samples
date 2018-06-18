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
                        ILogger<IPurchaseOrderHeaderRepository> logger,
                        IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
                        IApiPurchaseOrderHeaderRequestModelValidator purchaseOrderHeaderModelValidator,
                        IBOLPurchaseOrderHeaderMapper bolpurchaseOrderHeaderMapper,
                        IDALPurchaseOrderHeaderMapper dalpurchaseOrderHeaderMapper
                        ,
                        IBOLPurchaseOrderDetailMapper bolPurchaseOrderDetailMapper,
                        IDALPurchaseOrderDetailMapper dalPurchaseOrderDetailMapper

                        )
                        : base(logger,
                               purchaseOrderHeaderRepository,
                               purchaseOrderHeaderModelValidator,
                               bolpurchaseOrderHeaderMapper,
                               dalpurchaseOrderHeaderMapper
                               ,
                               bolPurchaseOrderDetailMapper,
                               dalPurchaseOrderDetailMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>2eb17cf86d52415ef7c1107d8952a499</Hash>
</Codenesium>*/