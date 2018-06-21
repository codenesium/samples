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
        [ApiVersion("1.0")]
        public class SubscriptionController : AbstractSubscriptionController
        {
                public SubscriptionController(
                        ApiSettings settings,
                        ILogger<SubscriptionController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISubscriptionService subscriptionService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               subscriptionService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>2cf7a8733242f790fd60bb30e1a60d83</Hash>
</Codenesium>*/