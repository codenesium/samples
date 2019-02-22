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
	[Route("api/callPersons")]
	[ApiController]
	[ApiVersion("1.0")]

	public class CallPersonController : AbstractCallPersonController
	{
		public CallPersonController(
			ApiSettings settings,
			ILogger<CallPersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICallPersonService callPersonService,
			IApiCallPersonServerModelMapper callPersonModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       callPersonService,
			       callPersonModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4caab96f121cc2d3e11dc3fe0e9531f8</Hash>
</Codenesium>*/