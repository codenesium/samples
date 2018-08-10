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
    <Hash>1e143d44659b58dcc924ce7f9d00eceb</Hash>
</Codenesium>*/