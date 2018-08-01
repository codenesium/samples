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

namespace NebulaNS.Api.Web
{
	[Route("api/linkLogs")]
	[ApiController]
	[ApiVersion("1.0")]
	public class LinkLogController : AbstractLinkLogController
	{
		public LinkLogController(
			ApiSettings settings,
			ILogger<LinkLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkLogService linkLogService,
			IApiLinkLogModelMapper linkLogModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       linkLogService,
			       linkLogModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e2911dfd05836d479dab01d7e7c8d21a</Hash>
</Codenesium>*/