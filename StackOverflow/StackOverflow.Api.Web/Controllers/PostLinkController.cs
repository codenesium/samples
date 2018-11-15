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
	[Route("api/postLinks")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class PostLinkController : AbstractPostLinkController
	{
		public PostLinkController(
			ApiSettings settings,
			ILogger<PostLinkController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPostLinkService postLinkService,
			IApiPostLinkServerModelMapper postLinkModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       postLinkService,
			       postLinkModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5238ab02d71fe2442f74058a8d4fbe27</Hash>
</Codenesium>*/