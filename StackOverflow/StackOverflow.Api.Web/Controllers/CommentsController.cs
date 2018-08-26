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
	public class CommentsController : AbstractCommentsController
	{
		public CommentsController(
			ApiSettings settings,
			ILogger<CommentsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICommentsService commentsService,
			IApiCommentsModelMapper commentsModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       commentsService,
			       commentsModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>51c5978b8db66a56796a46aacc8615aa</Hash>
</Codenesium>*/