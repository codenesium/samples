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
	public class SalesOrderHeadersController: AbstractSalesOrderHeadersController
	{
		public SalesOrderHeadersController(
			ILogger<SalesOrderHeadersController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderHeaderRepository salesOrderHeaderRepository,
			ISalesOrderHeaderModelValidator salesOrderHeaderModelValidator
			) : base(logger,
			         transactionCoordinator,
			         salesOrderHeaderRepository,
			         salesOrderHeaderModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0442f8052a32fa78564257df6fff7a61</Hash>
</Codenesium>*/