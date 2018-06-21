using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class DeploymentRepository : AbstractDeploymentRepository, IDeploymentRepository
        {
                public DeploymentRepository(
                        ILogger<DeploymentRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>9032bf3a77ad1582f1ec8e9a56409348</Hash>
</Codenesium>*/