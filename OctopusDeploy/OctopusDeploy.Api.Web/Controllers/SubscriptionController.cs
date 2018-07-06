using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/subscriptions")]
        [ApiController]
        [ApiVersion("1.0")]
        public class SubscriptionController : AbstractSubscriptionController
        {
                public SubscriptionController(
                        ApiSettings settings,
                        ILogger<SubscriptionController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISubscriptionService subscriptionService,
                        IApiSubscriptionModelMapper subscriptionModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               subscriptionService,
                               subscriptionModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>d12169661f9c751a996147a2b70472f1</Hash>
</Codenesium>*/