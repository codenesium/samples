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
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/projects")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ProjectController : AbstractProjectController
	{
		public ProjectController(
			ApiSettings settings,
			ILogger<ProjectController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProjectService projectService,
			IApiProjectModelMapper projectModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       projectService,
			       projectModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>cbca2199238a4b13eff373e143779418</Hash>
</Codenesium>*/