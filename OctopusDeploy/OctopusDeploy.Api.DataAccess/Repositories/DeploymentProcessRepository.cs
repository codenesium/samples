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
    <Hash>cf42c864a4dcdbee8522ee1e4bbcfae0</Hash>
</Codenesium>*/