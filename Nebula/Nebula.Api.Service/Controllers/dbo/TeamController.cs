using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	[Route("api/teams")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(TeamFilter))]
	public class TeamController: AbstractTeamController
	{
		public TeamController(
			ILogger<TeamController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeamRepository teamRepository
			)
			: base(logger,
			       transactionCoordinator,
			       teamRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6e6138dba017c18f428ff3b933129c22</Hash>
</Codenesium>*/