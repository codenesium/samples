using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.BusinessObjects;

namespace NebulaNS.Api.Service
{
	[Route("api/machines")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class MachineController: AbstractMachineController
	{
		public MachineController(
			ILogger<MachineController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOMachine machineManager
			)
			: base(logger,
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
    <Hash>b914d639b1f50fd7961cc48d0c2c1f67</Hash>
</Codenesium>*/