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
	public class SalesOrderHeaderSalesReasonsController: AbstractSalesOrderHeaderSalesReasonsController
	{
		public SalesOrderHeaderSalesReasonsController(
			ILogger<SalesOrderHeaderSalesReasonsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
			ISalesOrderHeaderSalesReasonModelValidator salesOrderHeaderSalesReasonModelValidator
			) : base(logger,
			         transactionCoordinator,
			         salesOrderHeaderSalesReasonRepository,
			         salesOrderHeaderSalesReasonModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3061bd04e4746c1bf4fa4c9eab2861cc</Hash>
</Codenesium>*/