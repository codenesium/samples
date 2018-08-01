using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>5ea9b28a9f1e992fbe3860b95b2557a0</Hash>
</Codenesium>*/