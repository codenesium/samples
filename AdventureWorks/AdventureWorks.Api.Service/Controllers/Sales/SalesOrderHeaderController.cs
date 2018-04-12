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
	[Route("api/salesOrderHeaders")]
	public class SalesOrderHeaderController: AbstractSalesOrderHeaderController
	{
		public SalesOrderHeaderController(
			ILogger<SalesOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderHeaderRepository salesOrderHeaderRepository,
			ISalesOrderHeaderModelValidator salesOrderHeaderModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       salesOrderHeaderRepository,
			       salesOrderHeaderModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>def4ca5b6ad82873665980cfa64d568b</Hash>
</Codenesium>*/