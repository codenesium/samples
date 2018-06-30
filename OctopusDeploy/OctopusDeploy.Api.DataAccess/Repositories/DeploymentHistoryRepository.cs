using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class DeploymentHistoryRepository : AbstractDeploymentHistoryRepository, IDeploymentHistoryRepository
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
    <Hash>4235166acd0846c936a97408a152695f</Hash>
</Codenesium>*/