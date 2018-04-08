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
	public class TeamsController: AbstractTeamsController
	{
		public TeamsController(
			ILogger<TeamsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITeamRepository teamRepository,
			ITeamModelValidator teamModelValidator
			) : base(logger,
			         transactionCoordinator,
			         teamRepository,
			         teamModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a9ecffcc8161981d34aacaf5ac640f82</Hash>
</Codenesium>*/