using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/purchaseOrderDetails")]
        [ApiVersion("1.0")]
        public class PurchaseOrderDetailController : AbstractPurchaseOrderDetailController
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
    <Hash>c8e18fbb0fd069ac2f1dfaa85fac0744</Hash>
</Codenesium>*/