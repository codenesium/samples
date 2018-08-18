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
    <Hash>86d9e43fc7f7f252352dbc651cde9d80</Hash>
</Codenesium>*/