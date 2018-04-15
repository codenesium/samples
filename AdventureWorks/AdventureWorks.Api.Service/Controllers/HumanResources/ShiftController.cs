using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/shifts")]
	[ApiVersion("1.0")]
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
    <Hash>49f859ccd0bf5a26d51600abe361c14e</Hash>
</Codenesium>*/