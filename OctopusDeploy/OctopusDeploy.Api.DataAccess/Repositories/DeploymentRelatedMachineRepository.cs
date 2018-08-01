using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class DeploymentRelatedMachineRepository : AbstractDeploymentRelatedMachineRepository, IDeploymentRelatedMachineRepository
	{
		public DeploymentRelatedMachineRepository(
			ILogger<DeploymentRelatedMachineRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ba487108b65a4e8cbcdd384d65d6c693</Hash>
</Codenesium>*/