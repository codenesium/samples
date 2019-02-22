using CADNS.Api.Contracts;
using CADNS.Api.Services;
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

namespace CADNS.Api.Web
{
	[Route("api/callDispositions")]
	[ApiController]
	[ApiVersion("1.0")]

	public class CallDispositionController : AbstractCallDispositionController
	{
		public CallDispositionController(
			ApiSettings settings,
			ILogger<CallDispositionController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICallDispositionService callDispositionService,
			IApiCallDispositionServerModelMapper callDispositionModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       callDispositionService,
			       callDispositionModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>44ee079cf63950bf69db96f3afde257c</Hash>
</Codenesium>*/