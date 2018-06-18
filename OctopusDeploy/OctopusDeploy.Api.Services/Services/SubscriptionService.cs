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
                               dalsubscriptionMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>c027af8ee452bd985964c03add47f80c</Hash>
</Codenesium>*/