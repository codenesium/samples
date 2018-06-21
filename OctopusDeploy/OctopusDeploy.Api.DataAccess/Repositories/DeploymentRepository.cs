using Codenesium.DataConversionExtensions;
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
    <Hash>105591a11be11ae61393027d157c4370</Hash>
</Codenesium>*/