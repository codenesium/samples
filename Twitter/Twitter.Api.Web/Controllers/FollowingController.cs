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
	[Route("api/followings")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class FollowingController : AbstractFollowingController
	{
		public FollowingController(
			ApiSettings settings,
			ILogger<FollowingController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFollowingService followingService,
			IApiFollowingModelMapper followingModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       followingService,
			       followingModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>78722969661747d0ac27fc68c3ef4667</Hash>
</Codenesium>*/