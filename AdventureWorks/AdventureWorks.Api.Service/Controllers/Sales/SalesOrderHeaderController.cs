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
	[Route("api/salesOrderHeaders")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(SalesOrderHeaderFilter))]
	public class SalesOrderHeaderController: AbstractSalesOrderHeaderController
	{
		public SalesOrderHeaderController(
			ILogger<SalesOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderHeaderRepository salesOrderHeaderRepository
			)
			: base(logger,
			       transactionCoordinator,
			       salesOrderHeaderRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c858dcfc59a5adbdd8a5e912d70643b9</Hash>
</Codenesium>*/