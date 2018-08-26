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
	public class PostLinksController : AbstractPostLinksController
	{
		public PostLinksController(
			ApiSettings settings,
			ILogger<PostLinksController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPostLinksService postLinksService,
			IApiPostLinksModelMapper postLinksModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       postLinksService,
			       postLinksModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>db40e5c3c501249ea9e53117cd356bf2</Hash>
</Codenesium>*/