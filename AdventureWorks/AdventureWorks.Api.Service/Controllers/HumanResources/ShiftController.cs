using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	[Route("api/shifts")]
	public class ShiftsController: AbstractShiftsController
	{
		public ShiftsController(
			ILogger<ShiftsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IShiftRepository shiftRepository,
			IShiftModelValidator shiftModelValidator
			) : base(logger,
			         transactionCoordinator,
			         shiftRepository,
			         shiftModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f1956786291124c2d7cd1df81969cad0</Hash>
</Codenesium>*/