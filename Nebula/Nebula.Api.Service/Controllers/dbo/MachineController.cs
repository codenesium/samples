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
	[Route("api/machines")]
	public class MachineController: AbstractMachineController
	{
		public MachineController(
			ILogger<MachineController> logger,
			ITransactionCoordinator transactionCoordinator,
			IMachineRepository machineRepository,
			IMachineModelValidator machineModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       machineRepository,
			       machineModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>dbf840ba32a2b63baed2c1e95f1b3715</Hash>
</Codenesium>*/