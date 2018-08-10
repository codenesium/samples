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
    <Hash>7f38461568c9d7bd0595620d7ddaf57c</Hash>
</Codenesium>*/