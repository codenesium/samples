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
	[Route("api/projectTriggers")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class ProjectTriggerController : AbstractProjectTriggerController
	{
		public ProjectTriggerController(
			ApiSettings settings,
			ILogger<ProjectTriggerController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProjectTriggerService projectTriggerService,
			IApiProjectTriggerModelMapper projectTriggerModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       projectTriggerService,
			       projectTriggerModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6020a278cff90bfd0d365dda58786351</Hash>
</Codenesium>*/