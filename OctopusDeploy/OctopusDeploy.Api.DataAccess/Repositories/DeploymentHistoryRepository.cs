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
    <Hash>23417279bcd7e326c1aaf6a3a2cd8856</Hash>
</Codenesium>*/