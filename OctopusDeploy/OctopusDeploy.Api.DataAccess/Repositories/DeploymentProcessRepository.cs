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
	public partial class DeploymentProcessRepository : AbstractDeploymentProcessRepository, IDeploymentProcessRepository
	{
		public DeploymentProcessRepository(
			ILogger<DeploymentProcessRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>eb84b54f4943d79f9a3ac4294a7d10cc</Hash>
</Codenesium>*/