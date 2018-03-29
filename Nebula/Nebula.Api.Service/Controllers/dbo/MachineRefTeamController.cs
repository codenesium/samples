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
			ApplicationContext context,
			IMachineRefTeamRepository machineRefTeamRepository,
			IMachineRefTeamModelValidator machineRefTeamModelValidator
			) : base(logger,
			         context,
			         machineRefTeamRepository,
			         machineRefTeamModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f152ad7c6c665f027603e4a0f558cb47</Hash>
</Codenesium>*/