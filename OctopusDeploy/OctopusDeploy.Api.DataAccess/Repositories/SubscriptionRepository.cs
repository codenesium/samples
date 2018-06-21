using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>c91fc076ca76542a210104c28628e0b2</Hash>
</Codenesium>*/