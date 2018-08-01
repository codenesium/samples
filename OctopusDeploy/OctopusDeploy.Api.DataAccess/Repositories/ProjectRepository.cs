using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>4b92c0ec71efb11978e3512e0f9d7db4</Hash>
</Codenesium>*/