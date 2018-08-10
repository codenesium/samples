using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
	[Route("api/voteTypes")]
	[ApiController]
	[ApiVersion("1.0")]
	public class VoteTypesController : AbstractVoteTypesController
	{
		public VoteTypesController(
			ApiSettings settings,
			ILogger<VoteTypesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVoteTypesService voteTypesService,
			IApiVoteTypesModelMapper voteTypesModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       voteTypesService,
			       voteTypesModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0d813ee2c4e5fe19dd236f3e727e9d35</Hash>
</Codenesium>*/