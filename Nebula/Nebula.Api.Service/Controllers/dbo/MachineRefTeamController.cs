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
	[Route("api/machineRefTeams")]
	[ApiVersion("1.0")]
	[Response]
	public class MachineRefTeamController: AbstractMachineRefTeamController
	{
		public MachineRefTeamController(
			ServiceSettings settings,
			ILogger<MachineRefTeamController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOMachineRefTeam machineRefTeamManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       machineRefTeamManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1526caa8fe35ca589da73092d7490b69</Hash>
</Codenesium>*/