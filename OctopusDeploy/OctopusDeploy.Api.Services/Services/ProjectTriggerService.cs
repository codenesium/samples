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
	public partial class ProjectTriggerService : AbstractProjectTriggerService, IProjectTriggerService
	{
		public ProjectTriggerService(
			ILogger<IProjectTriggerRepository> logger,
			IProjectTriggerRepository projectTriggerRepository,
			IApiProjectTriggerRequestModelValidator projectTriggerModelValidator,
			IBOLProjectTriggerMapper bolprojectTriggerMapper,
			IDALProjectTriggerMapper dalprojectTriggerMapper
			)
			: base(logger,
			       projectTriggerRepository,
			       projectTriggerModelValidator,
			       bolprojectTriggerMapper,
			       dalprojectTriggerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>539aad86c166eb2bf4e3cb757e2f52ea</Hash>
</Codenesium>*/