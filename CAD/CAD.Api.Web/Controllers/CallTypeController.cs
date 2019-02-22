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
	[Route("api/callTypes")]
	[ApiController]
	[ApiVersion("1.0")]

	public class CallTypeController : AbstractCallTypeController
	{
		public CallTypeController(
			ApiSettings settings,
			ILogger<CallTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICallTypeService callTypeService,
			IApiCallTypeServerModelMapper callTypeModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       callTypeService,
			       callTypeModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>14e92c0d0009625984e3bd490c47dc1f</Hash>
</Codenesium>*/