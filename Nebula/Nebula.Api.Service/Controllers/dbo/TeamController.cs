using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.BusinessObjects;

namespace NebulaNS.Api.Service
{
	[Route("api/teams")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class TeamController: AbstractTeamController
	{
		public TeamController(
			ILogger<TeamController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOTeam teamManager
			)
			: base(logger,
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
    <Hash>86507c72144544588ca5776b1d6b7e9d</Hash>
</Codenesium>*/