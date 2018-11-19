using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NebulaNS.Api.Web
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
			IApiTeamServerModelMapper teamModelMapper
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
    <Hash>648fe102cd8e0fe97907d3220597f138</Hash>
</Codenesium>*/