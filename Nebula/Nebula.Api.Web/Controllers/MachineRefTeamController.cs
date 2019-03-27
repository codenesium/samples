using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NebulaNS.Api.Web
{
	[Route("api/machineRefTeams")]
	[ApiController]
	[ApiVersion("1.0")]

	public class MachineRefTeamController : AbstractMachineRefTeamController
	{
		public MachineRefTeamController(
			ApiSettings settings,
			ILogger<MachineRefTeamController> logger,
			ITransactionCoordinator transactionCoordinator,
			IMachineRefTeamService machineRefTeamService,
			IApiMachineRefTeamServerModelMapper machineRefTeamModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       machineRefTeamService,
			       machineRefTeamModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>04388ce76d9f4f4dc82e547c0c1255a1</Hash>
</Codenesium>*/