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
			MachineRefTeamRepository machineRefTeamRepository,
			MachineRefTeamModelValidator machineRefTeamModelValidator
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
    <Hash>3ccfc9620c2ed2ac1da19a292fc5e0f0</Hash>
</Codenesium>*/