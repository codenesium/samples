using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class SubscriptionService : AbstractSubscriptionService, ISubscriptionService
        {
                public SubscriptionService(
                        ILogger<ISubscriptionRepository> logger,
                        ISubscriptionRepository subscriptionRepository,
                        IApiSubscriptionRequestModelValidator subscriptionModelValidator,
                        IBOLSubscriptionMapper bolsubscriptionMapper,
                        IDALSubscriptionMapper dalsubscriptionMapper
                        )
                        : base(logger,
                               subscriptionRepository,
                               subscriptionModelValidator,
                               bolsubscriptionMapper,
                               dalsubscriptionMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>c0bf1d6f7e54ca557afef8f83ab7e1b9</Hash>
</Codenesium>*/