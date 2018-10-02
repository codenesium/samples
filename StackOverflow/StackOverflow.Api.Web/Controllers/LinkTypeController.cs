using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Web
{
	[Route("api/linkTypes")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class LinkTypeController : AbstractLinkTypeController
	{
		public LinkTypeController(
			ApiSettings settings,
			ILogger<LinkTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkTypeService linkTypeService,
			IApiLinkTypeModelMapper linkTypeModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       linkTypeService,
			       linkTypeModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>517d962766fef57f525b06ebe68a2dd6</Hash>
</Codenesium>*/