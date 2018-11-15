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
	[Route("api/posts")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class PostController : AbstractPostController
	{
		public PostController(
			ApiSettings settings,
			ILogger<PostController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPostService postService,
			IApiPostServerModelMapper postModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       postService,
			       postModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>20752691298481a43f2b3710ffa2b989</Hash>
</Codenesium>*/