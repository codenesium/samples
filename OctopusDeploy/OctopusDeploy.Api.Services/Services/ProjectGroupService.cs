using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial class ProjectGroupService : AbstractProjectGroupService, IProjectGroupService
	{
		public ProjectGroupService(
			ILogger<IProjectGroupRepository> logger,
			IProjectGroupRepository projectGroupRepository,
			IApiProjectGroupRequestModelValidator projectGroupModelValidator,
			IBOLProjectGroupMapper bolprojectGroupMapper,
			IDALProjectGroupMapper dalprojectGroupMapper
			)
			: base(logger,
			       projectGroupRepository,
			       projectGroupModelValidator,
			       bolprojectGroupMapper,
			       dalprojectGroupMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6d6d93f2e5dc53120c57e7162265597c</Hash>
</Codenesium>*/