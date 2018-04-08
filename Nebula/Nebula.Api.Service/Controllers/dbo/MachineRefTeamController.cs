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
	public class MachineRefTeamsController: AbstractMachineRefTeamsController
	{
		public MachineRefTeamsController(
			ILogger<MachineRefTeamsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IMachineRefTeamRepository machineRefTeamRepository,
			IMachineRefTeamModelValidator machineRefTeamModelValidator
			) : base(logger,
			         transactionCoordinator,
			         machineRefTeamRepository,
			         machineRefTeamModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2ae787207aad3d296bb83a39bfa7abce</Hash>
</Codenesium>*/