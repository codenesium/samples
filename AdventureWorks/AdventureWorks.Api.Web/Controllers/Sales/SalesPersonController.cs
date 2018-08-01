using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/salesPersons")]
	[ApiController]
	[ApiVersion("1.0")]
	public class SalesPersonController : AbstractSalesPersonController
	{
		public SalesPersonController(
			ApiSettings settings,
			ILogger<SalesPersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesPersonService salesPersonService,
			IApiSalesPersonModelMapper salesPersonModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       salesPersonService,
			       salesPersonModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>50c5854d313c815b7b115a50c6eb40f0</Hash>
</Codenesium>*/