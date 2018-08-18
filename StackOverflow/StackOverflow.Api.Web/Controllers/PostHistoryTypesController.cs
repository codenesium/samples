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
	[Route("api/postHistoryTypes")]
	[ApiController]
	[ApiVersion("1.0")]
	public class PostHistoryTypesController : AbstractPostHistoryTypesController
	{
		public PostHistoryTypesController(
			ApiSettings settings,
			ILogger<PostHistoryTypesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPostHistoryTypesService postHistoryTypesService,
			IApiPostHistoryTypesModelMapper postHistoryTypesModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       postHistoryTypesService,
			       postHistoryTypesModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b35a880a78debceb68086d6cae1abd0e</Hash>
</Codenesium>*/