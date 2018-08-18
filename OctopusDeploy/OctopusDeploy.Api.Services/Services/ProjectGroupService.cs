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
    <Hash>e43bc1ed1532d55e23d9eb624984899a</Hash>
</Codenesium>*/