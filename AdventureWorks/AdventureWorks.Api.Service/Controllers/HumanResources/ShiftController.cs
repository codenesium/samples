using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/shifts")]
	[ApiVersion("1.0")]
	public class ShiftController: AbstractShiftController
	{
		public ShiftController(
			ILogger<ShiftController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOShift shiftManager
			)
			: base(logger,
			       transactionCoordinator,
			       shiftManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a8714f94c793f23e39f19af522200b35</Hash>
</Codenesium>*/