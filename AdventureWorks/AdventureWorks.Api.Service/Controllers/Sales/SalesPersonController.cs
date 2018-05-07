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
    <Hash>6d6f0d78dc36e87124643bb1172110f8</Hash>
</Codenesium>*/