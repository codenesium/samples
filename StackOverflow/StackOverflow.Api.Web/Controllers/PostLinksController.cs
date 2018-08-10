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
	[Route("api/postLinks")]
	[ApiController]
	[ApiVersion("1.0")]
	public class PostLinksController : AbstractPostLinksController
	{
		public PostLinksController(
			ApiSettings settings,
			ILogger<PostLinksController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPostLinksService postLinksService,
			IApiPostLinksModelMapper postLinksModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       postLinksService,
			       postLinksModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7a7cf63c1015cefd591d03aff165745a</Hash>
</Codenesium>*/