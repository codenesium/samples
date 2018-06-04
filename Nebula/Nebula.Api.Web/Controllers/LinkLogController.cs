using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;

namespace NebulaNS.Api.Web
{
	[Route("api/linkLogs")]
	[ApiVersion("1.0")]
	public class LinkLogController: AbstractLinkLogController
	{
		public LinkLogController(
			ServiceSettings settings,
			ILogger<LinkLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkLogService linkLogService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       linkLogService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f4298d426cab5e2d153840acba54969c</Hash>
</Codenesium>*/