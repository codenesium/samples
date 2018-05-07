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
using NebulaNS.Api.BusinessObjects;

namespace NebulaNS.Api.Service
{
	[Route("api/teams")]
	[ApiVersion("1.0")]
	public class TeamController: AbstractTeamController
	{
		public TeamController(
			ServiceSettings settings,
			ILogger<TeamController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOTeam teamManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       teamManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>40e5ab9a0f6b99d583a2391a6a98a67b</Hash>
</Codenesium>*/