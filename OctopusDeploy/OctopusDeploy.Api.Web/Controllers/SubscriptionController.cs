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
        [Route("api/subscriptions")]
        [ApiVersion("1.0")]
        public class SubscriptionController: AbstractSubscriptionController
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
    <Hash>dad9b591c080f71947d815e77c01efa6</Hash>
</Codenesium>*/