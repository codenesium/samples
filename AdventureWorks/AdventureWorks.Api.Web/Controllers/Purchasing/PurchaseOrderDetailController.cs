using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/purchaseOrderDetails")]
        [ApiVersion("1.0")]
        public class PurchaseOrderDetailController: AbstractPurchaseOrderDetailController
        {
                public PurchaseOrderDetailController(
                        ApiSettings settings,
                        ILogger<PurchaseOrderDetailController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPurchaseOrderDetailService purchaseOrderDetailService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               purchaseOrderDetailService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>d8445fcc43bd69c3ca1026eb91c13ed0</Hash>
</Codenesium>*/