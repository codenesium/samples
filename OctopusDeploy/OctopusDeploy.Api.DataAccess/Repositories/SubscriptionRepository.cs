using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class SubscriptionRepository: AbstractSubscriptionRepository, ISubscriptionRepository
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
    <Hash>791cd246ada633d0595a800d3858b886</Hash>
</Codenesium>*/