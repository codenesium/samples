using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/feeds")]
        [ApiVersion("1.0")]
        public class FeedController: AbstractFeedController
        {
                public FeedController(
                        ApiSettings settings,
                        ILogger<FeedController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IFeedService feedService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               feedService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>50329622186d4d631bb414c8d58d3c46</Hash>
</Codenesium>*/