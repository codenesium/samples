using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class DeploymentHistoryRepository : AbstractDeploymentHistoryRepository, IDeploymentHistoryRepository
        {
                public DeploymentHistoryRepository(
                        ILogger<DeploymentHistoryRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>dc2d152a5bd7caf2903ac3e0a822d361</Hash>
</Codenesium>*/