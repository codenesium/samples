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
	[Route("api/postHistoryTypes")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class PostHistoryTypeController : AbstractPostHistoryTypeController
	{
		public PostHistoryTypeController(
			ApiSettings settings,
			ILogger<PostHistoryTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPostHistoryTypeService postHistoryTypeService,
			IApiPostHistoryTypeServerModelMapper postHistoryTypeModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       postHistoryTypeService,
			       postHistoryTypeModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>76d81e419cb33c5801f7283540438180</Hash>
</Codenesium>*/