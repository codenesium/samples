using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	[Route("api/machines")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(MachineFilter))]
	public class MachineController: AbstractMachineController
	{
		public MachineController(
			ILogger<MachineController> logger,
			ITransactionCoordinator transactionCoordinator,
			IMachineRepository machineRepository
			)
			: base(logger,
			       transactionCoordinator,
			       machineRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4af46df2f46654486f06da6cc61f36f0</Hash>
</Codenesium>*/