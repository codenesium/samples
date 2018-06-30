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
        [Route("api/purchaseOrderHeaders")]
        [ApiVersion("1.0")]
        public class PurchaseOrderHeaderController : AbstractPurchaseOrderHeaderController
        {
                public PurchaseOrderHeaderController(
                        ApiSettings settings,
                        ILogger<PurchaseOrderHeaderController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPurchaseOrderHeaderService purchaseOrderHeaderService,
                        IApiPurchaseOrderHeaderModelMapper purchaseOrderHeaderModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               purchaseOrderHeaderService,
                               purchaseOrderHeaderModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>0335530bc9157f1d4f984a4a3b234fa0</Hash>
</Codenesium>*/