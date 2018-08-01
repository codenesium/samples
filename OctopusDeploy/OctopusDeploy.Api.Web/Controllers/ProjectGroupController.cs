using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/projectGroups")]
	[ApiController]
	[ApiVersion("1.0")]
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
    <Hash>e1600f55b77bd25a8a224d36f9d11107</Hash>
</Codenesium>*/