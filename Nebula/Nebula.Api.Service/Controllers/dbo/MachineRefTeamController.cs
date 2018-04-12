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
	[Route("api/machineRefTeams")]
	public class MachineRefTeamController: AbstractMachineRefTeamController
	{
		public MachineRefTeamController(
			ILogger<MachineRefTeamController> logger,
			ITransactionCoordinator transactionCoordinator,
			IMachineRefTeamRepository machineRefTeamRepository,
			IMachineRefTeamModelValidator machineRefTeamModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       machineRefTeamRepository,
			       machineRefTeamModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>438253e1dfbf1cd40ae882f956d8c616</Hash>
</Codenesium>*/