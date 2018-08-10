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
    <Hash>bfe88634f31a9b415958d354a243bc8c</Hash>
</Codenesium>*/