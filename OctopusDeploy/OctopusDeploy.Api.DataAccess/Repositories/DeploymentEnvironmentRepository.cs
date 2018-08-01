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
    <Hash>261e249da7c9ce8040557a97b269e431</Hash>
</Codenesium>*/