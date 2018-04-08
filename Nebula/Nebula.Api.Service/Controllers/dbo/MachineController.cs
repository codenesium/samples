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
	public class MachinesController: AbstractMachinesController
	{
		public MachinesController(
			ILogger<MachinesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IMachineRepository machineRepository,
			IMachineModelValidator machineModelValidator
			) : base(logger,
			         transactionCoordinator,
			         machineRepository,
			         machineModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>10be1ac0d710ac2ed5dd08c124460618</Hash>
</Codenesium>*/