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
	[Route("api/salesOrderHeaderSalesReasons")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(SalesOrderHeaderSalesReasonFilter))]
	public class SalesOrderHeaderSalesReasonController: AbstractSalesOrderHeaderSalesReasonController
	{
		public SalesOrderHeaderSalesReasonController(
			ILogger<SalesOrderHeaderSalesReasonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository
			)
			: base(logger,
			       transactionCoordinator,
			       salesOrderHeaderSalesReasonRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a79fbd186f2299d913e08f67a7233e9c</Hash>
</Codenesium>*/