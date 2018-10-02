using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.Services;

namespace TwitterNS.Api.Web
{
	[Route("api/likes")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class LikeController : AbstractLikeController
	{
		public LikeController(
			ApiSettings settings,
			ILogger<LikeController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILikeService likeService,
			IApiLikeModelMapper likeModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       likeService,
			       likeModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>59426ae7820b862ed1f03a5c15c8675d</Hash>
</Codenesium>*/