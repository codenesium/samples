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
                        ServiceSettings settings,
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
    <Hash>fc10a25bbd7db140ab5a483b994d5f85</Hash>
</Codenesium>*/