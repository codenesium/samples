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
        [Route("api/salesReasons")]
        [ApiVersion("1.0")]
        public class SalesReasonController : AbstractSalesReasonController
        {
                public SalesReasonController(
                        ApiSettings settings,
                        ILogger<SalesReasonController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesReasonService salesReasonService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               salesReasonService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>3aa0fa98c8bfa30974059093291d4fb4</Hash>
</Codenesium>*/