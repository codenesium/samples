using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class SubscriptionService: AbstractSubscriptionService, ISubscriptionService
        {
                public SubscriptionService(
                        ILogger<SubscriptionRepository> logger,
                        ISubscriptionRepository subscriptionRepository,
                        IApiSubscriptionRequestModelValidator subscriptionModelValidator,
                        IBOLSubscriptionMapper bolsubscriptionMapper,
                        IDALSubscriptionMapper dalsubscriptionMapper

                        )
                        : base(logger,
                               subscriptionRepository,
                               subscriptionModelValidator,
                               bolsubscriptionMapper,
                               dalsubscriptionMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>d6f9c440e514f47585b2bb5e652d52cb</Hash>
</Codenesium>*/