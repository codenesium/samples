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
	[Route("api/machines")]
	[ApiController]
	[ApiVersion("1.0")]
	public class MachineController : AbstractMachineController
	{
		public MachineController(
			ApiSettings settings,
			ILogger<MachineController> logger,
			ITransactionCoordinator transactionCoordinator,
			IMachineService machineService,
			IApiMachineModelMapper machineModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       machineService,
			       machineModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>060c33e34f8a6ac5da233d1350ef4c56</Hash>
</Codenesium>*/