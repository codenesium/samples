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
    <Hash>3be5d8604b4df749565557b635e83b17</Hash>
</Codenesium>*/