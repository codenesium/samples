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
	[Route("api/salesOrderDetails")]
	public class SalesOrderDetailsController: AbstractSalesOrderDetailsController
	{
		public SalesOrderDetailsController(
			ILogger<SalesOrderDetailsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderDetailRepository salesOrderDetailRepository,
			ISalesOrderDetailModelValidator salesOrderDetailModelValidator
			) : base(logger,
			         transactionCoordinator,
			         salesOrderDetailRepository,
			         salesOrderDetailModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>633be548d672333aa61016aaf398e519</Hash>
</Codenesium>*/