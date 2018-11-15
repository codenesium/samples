using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
	[Authorize(Policy = "DefaultAccess")]

	public class SalesPersonController : AbstractSalesPersonController
	{
		public SalesPersonController(
			ApiSettings settings,
			ILogger<SalesPersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesPersonService salesPersonService,
			IApiSalesPersonServerModelMapper salesPersonModelMapper
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
    <Hash>315446fd29bb048d0fa986bd62850ac4</Hash>
</Codenesium>*/