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
			ApplicationContext context,
			ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
			ISalesOrderHeaderSalesReasonModelValidator salesOrderHeaderSalesReasonModelValidator
			) : base(logger,
			         context,
			         salesOrderHeaderSalesReasonRepository,
			         salesOrderHeaderSalesReasonModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>37d6bed584c88d2ef82fc4d664c487a9</Hash>
</Codenesium>*/