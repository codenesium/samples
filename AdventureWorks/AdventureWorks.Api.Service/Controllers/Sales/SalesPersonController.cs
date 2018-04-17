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
	[Route("api/salesPersons")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class SalesPersonController: AbstractSalesPersonController
	{
		public SalesPersonController(
			ILogger<SalesPersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesPerson salesPersonManager
			)
			: base(logger,
			       transactionCoordinator,
			       salesPersonManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>be06ceb55d9fa8016beed52334666423</Hash>
</Codenesium>*/