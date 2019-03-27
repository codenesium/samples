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

	public class CallStatusController : AbstractCallStatusController
	{
		public CallStatusController(
			ApiSettings settings,
			ILogger<CallStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICallStatusService callStatusService,
			IApiCallStatusServerModelMapper callStatusModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       callStatusService,
			       callStatusModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b9b6d54c48fb51e39f7dba88cb355089</Hash>
</Codenesium>*/