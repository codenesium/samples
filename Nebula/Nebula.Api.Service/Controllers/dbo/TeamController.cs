using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	[Route("api/teams")]
	public class TeamController: AbstractTeamController
	{
		public TeamController(
			ILogger<TeamController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeamRepository teamRepository,
			ITeamModelValidator teamModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       teamRepository,
			       teamModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ad2e04fab5ba7bca0e14d19389668d61</Hash>
</Codenesium>*/