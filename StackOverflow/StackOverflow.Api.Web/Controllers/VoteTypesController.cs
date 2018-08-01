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
    <Hash>b4ce90fee5c46865e79863c5b579717e</Hash>
</Codenesium>*/