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
	public partial class ProjectService : AbstractProjectService, IProjectService
	{
		public ProjectService(
			ILogger<IProjectRepository> logger,
			IProjectRepository projectRepository,
			IApiProjectRequestModelValidator projectModelValidator,
			IBOLProjectMapper bolprojectMapper,
			IDALProjectMapper dalprojectMapper
			)
			: base(logger,
			       projectRepository,
			       projectModelValidator,
			       bolprojectMapper,
			       dalprojectMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7db7d206739a057f33783fdab780cc1c</Hash>
</Codenesium>*/