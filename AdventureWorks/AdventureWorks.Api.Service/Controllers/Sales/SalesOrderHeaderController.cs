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
			ApplicationContext context,
			ISalesOrderHeaderRepository salesOrderHeaderRepository,
			ISalesOrderHeaderModelValidator salesOrderHeaderModelValidator
			) : base(logger,
			         context,
			         salesOrderHeaderRepository,
			         salesOrderHeaderModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>de7f498560e27679e61d60e6aaafc25e</Hash>
</Codenesium>*/