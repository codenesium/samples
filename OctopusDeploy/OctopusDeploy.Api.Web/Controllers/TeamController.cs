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
    <Hash>173230f7a92970e25e7a6c4b1755b3c1</Hash>
</Codenesium>*/