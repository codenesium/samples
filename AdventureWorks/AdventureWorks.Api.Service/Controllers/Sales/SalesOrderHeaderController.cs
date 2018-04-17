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
	[Route("api/salesOrderHeaders")]
	[ApiVersion("1.0")]
	public class SalesOrderHeaderController: AbstractSalesOrderHeaderController
	{
		public SalesOrderHeaderController(
			ILogger<SalesOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesOrderHeader salesOrderHeaderManager
			)
			: base(logger,
			       transactionCoordinator,
			       salesOrderHeaderManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1bfb491a2cb0307246767cc518a38073</Hash>
</Codenesium>*/