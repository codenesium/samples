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
			IApiFollowingServerModelMapper followingModelMapper
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
    <Hash>1cdd0d0f338ad9edf1495bdb3df7e8a2</Hash>
</Codenesium>*/