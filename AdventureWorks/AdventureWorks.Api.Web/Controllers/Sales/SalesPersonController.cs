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
using System.Threading.Tasks;

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
    <Hash>a9d7f9c7a5b4f3bc56744c5bd4bd9e70</Hash>
</Codenesium>*/