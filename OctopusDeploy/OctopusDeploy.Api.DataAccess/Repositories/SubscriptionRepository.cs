using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class SubscriptionRepository : AbstractSubscriptionRepository, ISubscriptionRepository
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
    <Hash>13f83c0f5af532f67980e35276c04d73</Hash>
</Codenesium>*/