using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class SubscriptionRepository : AbstractSubscriptionRepository, ISubscriptionRepository
        {
                public SubscriptionRepository(
                        ILogger<SubscriptionRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>318c3900dfc25687875000094813e77d</Hash>
</Codenesium>*/