using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/salesOrderHeaderSalesReasons")]
	public class SalesOrderHeaderSalesReasonController: AbstractSalesOrderHeaderSalesReasonController
	{
		public SalesOrderHeaderSalesReasonController(
			ILogger<SalesOrderHeaderSalesReasonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
			ISalesOrderHeaderSalesReasonModelValidator salesOrderHeaderSalesReasonModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       salesOrderHeaderSalesReasonRepository,
			       salesOrderHeaderSalesReasonModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>829d2f49026125632e1defef11b19c90</Hash>
</Codenesium>*/