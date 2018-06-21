using Codenesium.DataConversionExtensions;
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
    <Hash>502dfd1deb23a19e7486a56b99dd53f6</Hash>
</Codenesium>*/