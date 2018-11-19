using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
			IApiLinkLogServerModelMapper linkLogModelMapper
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
    <Hash>52da9c2aa618d75e3a318d77ce6dcce1</Hash>
</Codenesium>*/