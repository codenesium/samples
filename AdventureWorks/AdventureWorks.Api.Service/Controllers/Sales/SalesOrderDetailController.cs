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
	[Route("api/salesOrderDetails")]
	[ApiVersion("1.0")]
	[Response]
	public class SalesOrderDetailController: AbstractSalesOrderDetailController
	{
		public SalesOrderDetailController(
			ServiceSettings settings,
			ILogger<SalesOrderDetailController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesOrderDetail salesOrderDetailManager
			)
			: base(settings,
			       logger,
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
    <Hash>7d16961b6512ee784a5cb69254086568</Hash>
</Codenesium>*/