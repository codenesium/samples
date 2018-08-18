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
	public partial class ProjectTriggerRepository : AbstractProjectTriggerRepository, IProjectTriggerRepository
	{
		public ProjectTriggerRepository(
			ILogger<ProjectTriggerRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>53b27fcd6b13c8561aae2bb2dc3b3206</Hash>
</Codenesium>*/