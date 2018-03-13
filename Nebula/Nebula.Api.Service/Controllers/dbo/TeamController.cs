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
			TeamRepository teamRepository,
			TeamModelValidator teamModelValidator
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
    <Hash>23eb43969a184dadef66d735f31ff3d9</Hash>
</Codenesium>*/