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
	public class ShiftController: AbstractShiftController
	{
		public ShiftController(
			ILogger<ShiftController> logger,
			ITransactionCoordinator transactionCoordinator,
			IShiftRepository shiftRepository,
			IShiftModelValidator shiftModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       shiftRepository,
			       shiftModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>412539f4ace9c4bd42acbeb5c2940da9</Hash>
</Codenesium>*/