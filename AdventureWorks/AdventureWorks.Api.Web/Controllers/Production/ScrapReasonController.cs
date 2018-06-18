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
        [Route("api/scrapReasons")]
        [ApiVersion("1.0")]
        public class ScrapReasonController: AbstractScrapReasonController
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
    <Hash>200b58b724765cb49b896f7b4e8ba629</Hash>
</Codenesium>*/