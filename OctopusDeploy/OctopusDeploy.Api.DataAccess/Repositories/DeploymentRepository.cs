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
    <Hash>d784fdf42c77faed2613610a7b2ce139</Hash>
</Codenesium>*/