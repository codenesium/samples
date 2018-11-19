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
	[Route("api/salesReasons")]
	[ApiController]
	[ApiVersion("1.0")]

	public class SalesReasonController : AbstractSalesReasonController
	{
		public SalesReasonController(
			ApiSettings settings,
			ILogger<SalesReasonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesReasonService salesReasonService,
			IApiSalesReasonServerModelMapper salesReasonModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       salesReasonService,
			       salesReasonModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>81ea2a50c5871cfea074e2ff5a5bde45</Hash>
</Codenesium>*/