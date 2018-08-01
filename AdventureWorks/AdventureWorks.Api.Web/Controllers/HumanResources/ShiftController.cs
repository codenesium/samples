using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/shifts")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ShiftController : AbstractShiftController
	{
		public ShiftController(
			ApiSettings settings,
			ILogger<ShiftController> logger,
			ITransactionCoordinator transactionCoordinator,
			IShiftService shiftService,
			IApiShiftModelMapper shiftModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       shiftService,
			       shiftModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a05364cb775782e3c3176239f7ce8e19</Hash>
</Codenesium>*/