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
	[Route("api/postHistory")]
	[ApiController]
	[ApiVersion("1.0")]

	public class PostHistoryController : AbstractPostHistoryController
	{
		public PostHistoryController(
			ApiSettings settings,
			ILogger<PostHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPostHistoryService postHistoryService,
			IApiPostHistoryServerModelMapper postHistoryModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       postHistoryService,
			       postHistoryModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>658bdff71e18c0c9ecbf1b463a3c79a9</Hash>
</Codenesium>*/