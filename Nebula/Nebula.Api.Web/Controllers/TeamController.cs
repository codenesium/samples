using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;

namespace NebulaNS.Api.Web
{
	[Route("api/teams")]
	[ApiVersion("1.0")]
	public class TeamController: AbstractTeamController
	{
		public TeamController(
			ServiceSettings settings,
			ILogger<TeamController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeamService teamService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       teamService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>74ba2cb855b5450d6c6592b6548f253d</Hash>
</Codenesium>*/