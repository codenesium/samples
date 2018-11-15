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
	[Route("api/links")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class LinkController : AbstractLinkController
	{
		public LinkController(
			ApiSettings settings,
			ILogger<LinkController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkService linkService,
			IApiLinkServerModelMapper linkModelMapper
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
    <Hash>0c6d4fc0b2633c1ca0e17ae241e95ce3</Hash>
</Codenesium>*/