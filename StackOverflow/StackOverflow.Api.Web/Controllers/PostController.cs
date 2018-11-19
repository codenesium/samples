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
    <Hash>4bf7656a94d0f8387a8194d57fdf2898</Hash>
</Codenesium>*/