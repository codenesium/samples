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
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/salesOrderHeaderSalesReasons")]
	[ApiVersion("1.0")]
	public class SalesOrderHeaderSalesReasonController: AbstractSalesOrderHeaderSalesReasonController
	{
		public SalesOrderHeaderSalesReasonController(
			ServiceSettings settings,
			ILogger<SalesOrderHeaderSalesReasonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesOrderHeaderSalesReasonService salesOrderHeaderSalesReasonService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       salesOrderHeaderSalesReasonService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>eb211e078c7ab4c5ce091fce8f6b0374</Hash>
</Codenesium>*/