using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/shifts")]
	[ApiVersion("1.0")]
	[Response]
	public class ShiftController: AbstractShiftController
	{
		public ShiftController(
			ServiceSettings settings,
			ILogger<ShiftController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOShift shiftManager
			)
			: base(settings,
			       logger,
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
    <Hash>f4973f533473048fbf379b806c06d566</Hash>
</Codenesium>*/