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
	[Route("api/machineRefTeams")]
	[ApiVersion("1.0")]
	public class MachineRefTeamController: AbstractMachineRefTeamController
	{
		public MachineRefTeamController(
			ILogger<MachineRefTeamController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOMachineRefTeam machineRefTeamManager
			)
			: base(logger,
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
    <Hash>f85da663fcc1345432452115e1c2136c</Hash>
</Codenesium>*/