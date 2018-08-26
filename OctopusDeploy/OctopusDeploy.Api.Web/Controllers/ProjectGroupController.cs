using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/projectGroups")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class ProjectGroupController : AbstractProjectGroupController
	{
		public ProjectGroupController(
			ApiSettings settings,
			ILogger<ProjectGroupController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProjectGroupService projectGroupService,
			IApiProjectGroupModelMapper projectGroupModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       projectGroupService,
			       projectGroupModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9eb1b0e68ff67a682acc4405efce52f5</Hash>
</Codenesium>*/