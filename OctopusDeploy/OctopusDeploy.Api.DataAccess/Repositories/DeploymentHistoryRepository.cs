using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class DeploymentHistoryRepository: AbstractDeploymentHistoryRepository, IDeploymentHistoryRepository
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
    <Hash>28cdec5c73667ce30de820595114443a</Hash>
</Codenesium>*/