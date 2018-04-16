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
	[ServiceFilter(typeof(ShiftFilter))]
	public class ShiftController: AbstractShiftController
	{
		public ShiftController(
			ILogger<ShiftController> logger,
			ITransactionCoordinator transactionCoordinator,
			IShiftRepository shiftRepository
			)
			: base(logger,
			       transactionCoordinator,
			       shiftRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9e34d2058e0da467e8346397a3c5a367</Hash>
</Codenesium>*/