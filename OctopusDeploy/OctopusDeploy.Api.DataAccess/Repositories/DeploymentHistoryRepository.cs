using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class DeploymentHistoryRepository : AbstractDeploymentHistoryRepository, IDeploymentHistoryRepository
	{
		public DeploymentHistoryRepository(
			ILogger<DeploymentHistoryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>89e80e4768e80ad99590b04b186b3bcc</Hash>
</Codenesium>*/