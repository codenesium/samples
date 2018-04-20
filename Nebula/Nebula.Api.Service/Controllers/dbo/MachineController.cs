using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.BusinessObjects;

namespace NebulaNS.Api.Service
{
	[Route("api/machines")]
	[ApiVersion("1.0")]
	[Response]
	public class MachineController: AbstractMachineController
	{
		public MachineController(
			ServiceSettings settings,
			ILogger<MachineController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOMachine machineManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       machineManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>18788fda9fec8536ca024c316d0777c0</Hash>
</Codenesium>*/