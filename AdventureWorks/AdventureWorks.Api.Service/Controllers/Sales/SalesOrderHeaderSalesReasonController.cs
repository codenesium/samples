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
	[Route("api/salesOrderHeaderSalesReasons")]
	[ApiVersion("1.0")]
	[Response]
	public class SalesOrderHeaderSalesReasonController: AbstractSalesOrderHeaderSalesReasonController
	{
		public SalesOrderHeaderSalesReasonController(
			ServiceSettings settings,
			ILogger<SalesOrderHeaderSalesReasonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesOrderHeaderSalesReason salesOrderHeaderSalesReasonManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       salesOrderHeaderSalesReasonManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>fc8ce08c9155b1b0b11bf06c2fdfe375</Hash>
</Codenesium>*/