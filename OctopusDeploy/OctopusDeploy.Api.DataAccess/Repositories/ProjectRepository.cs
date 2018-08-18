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
	public partial class ProjectRepository : AbstractProjectRepository, IProjectRepository
	{
		public ProjectRepository(
			ILogger<ProjectRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>159356a1509ba1e1635a1d1cbe4d3d08</Hash>
</Codenesium>*/