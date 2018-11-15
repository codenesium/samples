using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/shifts")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class ShiftController : AbstractShiftController
	{
		public ShiftController(
			ApiSettings settings,
			ILogger<ShiftController> logger,
			ITransactionCoordinator transactionCoordinator,
			IShiftService shiftService,
			IApiShiftServerModelMapper shiftModelMapper
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
    <Hash>7ed8a517f1b99bd33bce4d6ad220cc97</Hash>
</Codenesium>*/