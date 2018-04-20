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
	[Route("api/salesOrderHeaders")]
	[ApiVersion("1.0")]
	[Response]
	public class SalesOrderHeaderController: AbstractSalesOrderHeaderController
	{
		public SalesOrderHeaderController(
			ServiceSettings settings,
			ILogger<SalesOrderHeaderController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesOrderHeader salesOrderHeaderManager
			)
			: base(settings,
			       logger,
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
    <Hash>f60e28fd41afe78daafe0ecf00b2d95f</Hash>
</Codenesium>*/