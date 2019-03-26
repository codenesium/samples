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
	[Route("api/votes")]
	[ApiController]
	[ApiVersion("1.0")]

	public class VoteController : AbstractVoteController
	{
		public VoteController(
			ApiSettings settings,
			ILogger<VoteController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVoteService voteService,
			IApiVoteServerModelMapper voteModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       voteService,
			       voteModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>31a0ebbf69f5b198f3df530693f01a20</Hash>
</Codenesium>*/