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
	[Route("api/teams")]
	[ApiController]
	[ApiVersion("1.0")]
	public class TeamController : AbstractTeamController
	{
		public TeamController(
			ApiSettings settings,
			ILogger<TeamController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeamService teamService,
			IApiTeamModelMapper teamModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       teamService,
			       teamModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b15d7e2dc6eacaf949bf5bdaf0656225</Hash>
</Codenesium>*/