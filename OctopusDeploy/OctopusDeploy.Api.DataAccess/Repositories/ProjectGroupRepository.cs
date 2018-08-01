using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class ProjectGroupRepository : AbstractProjectGroupRepository, IProjectGroupRepository
	{
		public ProjectGroupRepository(
			ILogger<ProjectGroupRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>45241f925d70180588ed5226642f7517</Hash>
</Codenesium>*/