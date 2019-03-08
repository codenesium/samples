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

	public class VotesController : AbstractVotesController
	{
		public VotesController(
			ApiSettings settings,
			ILogger<VotesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVotesService votesService,
			IApiVotesServerModelMapper votesModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       votesService,
			       votesModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>be84f42c8416560a9b2ff68f8223ffc6</Hash>
</Codenesium>*/