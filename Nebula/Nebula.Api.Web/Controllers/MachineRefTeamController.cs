using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
			IApiMachineRefTeamModelMapper machineRefTeamModelMapper
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
    <Hash>dbad9df83361e9214d868bc35c18f85c</Hash>
</Codenesium>*/