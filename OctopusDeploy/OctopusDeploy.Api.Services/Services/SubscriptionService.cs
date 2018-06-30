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
        public partial class SubscriptionService : AbstractSubscriptionService, ISubscriptionService
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
    <Hash>4389a0e728a9b3e2880cb899fa5c8136</Hash>
</Codenesium>*/