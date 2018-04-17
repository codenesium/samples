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
	[Route("api/salesOrderDetails")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class SalesOrderDetailController: AbstractSalesOrderDetailController
	{
		public SalesOrderDetailController(
			ILogger<SalesOrderDetailController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesOrderDetail salesOrderDetailManager
			)
			: base(logger,
			       transactionCoordinator,
			       salesOrderDetailManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d821aa0950abd05379a3577814e5d77f</Hash>
</Codenesium>*/