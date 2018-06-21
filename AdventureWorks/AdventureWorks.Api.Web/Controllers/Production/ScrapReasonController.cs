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
        [Route("api/scrapReasons")]
        [ApiVersion("1.0")]
        public class ScrapReasonController : AbstractScrapReasonController
        {
                public ScrapReasonController(
                        ApiSettings settings,
                        ILogger<ScrapReasonController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IScrapReasonService scrapReasonService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               scrapReasonService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>288ab2d60a82bf0f29106b20ee553078</Hash>
</Codenesium>*/