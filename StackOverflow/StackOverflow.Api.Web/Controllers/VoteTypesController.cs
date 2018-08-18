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
    <Hash>2020130fddfa066571b417be97a8c7f6</Hash>
</Codenesium>*/