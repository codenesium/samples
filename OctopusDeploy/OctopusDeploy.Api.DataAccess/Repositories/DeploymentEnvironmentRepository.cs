using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>c92396c1e2e0da2f8da7f75a8a28fad6</Hash>
</Codenesium>*/