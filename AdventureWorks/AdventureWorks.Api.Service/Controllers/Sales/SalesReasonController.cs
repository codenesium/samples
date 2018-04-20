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
	[Route("api/salesReasons")]
	[ApiVersion("1.0")]
	[Response]
	public class SalesReasonController: AbstractSalesReasonController
	{
		public SalesReasonController(
			ServiceSettings settings,
			ILogger<SalesReasonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesReason salesReasonManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       salesReasonManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6d2981ed354b3af2f4f36e33e8eede35</Hash>
</Codenesium>*/