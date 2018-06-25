using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class DeploymentEnvironmentRepository : AbstractDeploymentEnvironmentRepository, IDeploymentEnvironmentRepository
        {
                public DeploymentEnvironmentRepository(
                        ILogger<DeploymentEnvironmentRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a60b35f8e0476ea0792fc19df1f05f93</Hash>
</Codenesium>*/