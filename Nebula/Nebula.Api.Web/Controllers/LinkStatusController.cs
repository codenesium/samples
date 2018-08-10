using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NebulaNS.Api.Web
{
	[Route("api/linkStatus")]
	[ApiController]
	[ApiVersion("1.0")]
	public class LinkStatusController : AbstractLinkStatusController
	{
		public LinkStatusController(
			ApiSettings settings,
			ILogger<LinkStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkStatusService linkStatusService,
			IApiLinkStatusModelMapper linkStatusModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       linkStatusService,
			       linkStatusModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9e0fbdc6a35adcd160c0787ed4d00341</Hash>
</Codenesium>*/