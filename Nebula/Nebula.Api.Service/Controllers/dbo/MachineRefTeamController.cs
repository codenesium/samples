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
	[Route("api/machineRefTeams")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(MachineRefTeamFilter))]
	public class MachineRefTeamController: AbstractMachineRefTeamController
	{
		public MachineRefTeamController(
			ILogger<MachineRefTeamController> logger,
			ITransactionCoordinator transactionCoordinator,
			IMachineRefTeamRepository machineRefTeamRepository
			)
			: base(logger,
			       transactionCoordinator,
			       machineRefTeamRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1163d89711642d7d55ea2af39d77c14a</Hash>
</Codenesium>*/