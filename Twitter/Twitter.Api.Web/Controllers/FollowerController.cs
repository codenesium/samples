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
	[Route("api/followers")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class FollowerController : AbstractFollowerController
	{
		public FollowerController(
			ApiSettings settings,
			ILogger<FollowerController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFollowerService followerService,
			IApiFollowerServerModelMapper followerModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       followerService,
			       followerModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>69dc190248301d23a113dc010129d79f</Hash>
</Codenesium>*/