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
	public class MachineRefTeamsController: MachineRefTeamsControllerAbstract
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
    <Hash>aa17ca31f400435d05dac1a2f0c5b931</Hash>
</Codenesium>*/