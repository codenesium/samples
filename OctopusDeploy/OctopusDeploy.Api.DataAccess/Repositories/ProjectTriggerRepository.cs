using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>a4fda3ff90bef309fde63945d1ae0c2b</Hash>
</Codenesium>*/