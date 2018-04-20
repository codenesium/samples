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
	[Route("api/salesPersons")]
	[ApiVersion("1.0")]
	[Response]
	public class SalesPersonController: AbstractSalesPersonController
	{
		public SalesPersonController(
			ServiceSettings settings,
			ILogger<SalesPersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesPerson salesPersonManager
			)
			: base(settings,
			       logger,
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
    <Hash>d4e91831f84e9127a77470754767af78</Hash>
</Codenesium>*/