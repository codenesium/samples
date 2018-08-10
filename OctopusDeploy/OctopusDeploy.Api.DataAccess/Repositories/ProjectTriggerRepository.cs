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
    <Hash>a2bdb78ae3d04a97f7a9ee86106011f6</Hash>
</Codenesium>*/