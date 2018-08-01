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
	[Route("api/links")]
	[ApiController]
	[ApiVersion("1.0")]
	public class LinkController : AbstractLinkController
	{
		public LinkController(
			ApiSettings settings,
			ILogger<LinkController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkService linkService,
			IApiLinkModelMapper linkModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       linkService,
			       linkModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>19a7da6c0b2c6461859d057dde847d7c</Hash>
</Codenesium>*/