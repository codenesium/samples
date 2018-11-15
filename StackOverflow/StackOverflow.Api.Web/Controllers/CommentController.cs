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
	[Route("api/comments")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class CommentController : AbstractCommentController
	{
		public CommentController(
			ApiSettings settings,
			ILogger<CommentController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICommentService commentService,
			IApiCommentServerModelMapper commentModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       commentService,
			       commentModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>05b7928b657f52da12018f318fd6373c</Hash>
</Codenesium>*/