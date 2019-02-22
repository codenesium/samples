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
	[Route("api/callStatus")]
	[ApiController]
	[ApiVersion("1.0")]

	public class CallStatuController : AbstractCallStatuController
	{
		public CallStatuController(
			ApiSettings settings,
			ILogger<CallStatuController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICallStatuService callStatuService,
			IApiCallStatuServerModelMapper callStatuModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       callStatuService,
			       callStatuModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>762e28c482249d06992630b1f474ef4e</Hash>
</Codenesium>*/