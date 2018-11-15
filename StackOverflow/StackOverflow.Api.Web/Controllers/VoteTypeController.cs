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
	[Route("api/voteTypes")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class VoteTypeController : AbstractVoteTypeController
	{
		public VoteTypeController(
			ApiSettings settings,
			ILogger<VoteTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVoteTypeService voteTypeService,
			IApiVoteTypeServerModelMapper voteTypeModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       voteTypeService,
			       voteTypeModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c324c98de9042e84cde22b63f89b1fe2</Hash>
</Codenesium>*/