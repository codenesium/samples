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
	[Route("api/calls")]
	[ApiController]
	[ApiVersion("1.0")]

	public class CallController : AbstractCallController
	{
		public CallController(
			ApiSettings settings,
			ILogger<CallController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICallService callService,
			IApiCallServerModelMapper callModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       callService,
			       callModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c3b82657a1d39f06a43617b58ee8bb39</Hash>
</Codenesium>*/