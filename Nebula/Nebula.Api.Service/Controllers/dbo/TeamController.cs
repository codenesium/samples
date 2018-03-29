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
			ApplicationContext context,
			ITeamRepository teamRepository,
			ITeamModelValidator teamModelValidator
			) : base(logger,
			         context,
			         teamRepository,
			         teamModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3908fce84b5b0a83daf4cde133d4548d</Hash>
</Codenesium>*/