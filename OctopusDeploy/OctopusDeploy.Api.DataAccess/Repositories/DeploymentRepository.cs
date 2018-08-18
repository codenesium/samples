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
	public partial class DeploymentRepository : AbstractDeploymentRepository, IDeploymentRepository
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
    <Hash>112b76798c926155bea7973602b70fb5</Hash>
</Codenesium>*/