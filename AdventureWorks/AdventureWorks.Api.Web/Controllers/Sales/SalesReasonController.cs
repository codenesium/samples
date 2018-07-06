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
        [ApiController]
        [ApiVersion("1.0")]
        public class SalesReasonController : AbstractSalesReasonController
        {
                public SalesReasonController(
                        ApiSettings settings,
                        ILogger<SalesReasonController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesReasonService salesReasonService,
                        IApiSalesReasonModelMapper salesReasonModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               salesReasonService,
                               salesReasonModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>82d6d16ea294b2b297a8709a09c073c7</Hash>
</Codenesium>*/