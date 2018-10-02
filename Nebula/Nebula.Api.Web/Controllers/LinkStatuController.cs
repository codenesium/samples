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
	[Route("api/linkStatus")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class LinkStatuController : AbstractLinkStatuController
	{
		public LinkStatuController(
			ApiSettings settings,
			ILogger<LinkStatuController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkStatuService linkStatuService,
			IApiLinkStatuModelMapper linkStatuModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       linkStatuService,
			       linkStatuModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0ca8a6f049100be0a3b380106fb3e6da</Hash>
</Codenesium>*/