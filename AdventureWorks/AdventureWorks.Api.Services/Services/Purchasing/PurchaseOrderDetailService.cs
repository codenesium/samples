using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public partial class PurchaseOrderDetailService : AbstractPurchaseOrderDetailService, IPurchaseOrderDetailService
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
    <Hash>8b900b831e62b9c4b7c7202f62c17c2e</Hash>
</Codenesium>*/