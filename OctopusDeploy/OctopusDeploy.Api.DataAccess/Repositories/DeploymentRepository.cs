using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>912da809d05c10f110e89d232d8d5c00</Hash>
</Codenesium>*/