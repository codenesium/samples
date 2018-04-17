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
	[Route("api/salesReasons")]
	[ApiVersion("1.0")]
	public class SalesReasonController: AbstractSalesReasonController
	{
		public SalesReasonController(
			ILogger<SalesReasonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesReason salesReasonManager
			)
			: base(logger,
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
    <Hash>0437853fbc6632a4e402d03a9ca96da5</Hash>
</Codenesium>*/