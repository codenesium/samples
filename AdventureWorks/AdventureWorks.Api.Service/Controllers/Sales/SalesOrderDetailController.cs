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
	[Route("api/salesOrderDetails")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(SalesOrderDetailFilter))]
	public class SalesOrderDetailController: AbstractSalesOrderDetailController
	{
		public SalesOrderDetailController(
			ILogger<SalesOrderDetailController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderDetailRepository salesOrderDetailRepository
			)
			: base(logger,
			       transactionCoordinator,
			       salesOrderDetailRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>65c435781fc6e359140c7fd0e169e37c</Hash>
</Codenesium>*/