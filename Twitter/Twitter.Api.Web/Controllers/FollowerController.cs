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
			IApiFollowerModelMapper followerModelMapper
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
    <Hash>6a3db34cf8994dfd45ae504d8366f3b3</Hash>
</Codenesium>*/