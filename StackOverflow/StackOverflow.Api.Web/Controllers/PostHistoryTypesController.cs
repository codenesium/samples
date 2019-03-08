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

	public class PostHistoryTypesController : AbstractPostHistoryTypesController
	{
		public PostHistoryTypesController(
			ApiSettings settings,
			ILogger<PostHistoryTypesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPostHistoryTypesService postHistoryTypesService,
			IApiPostHistoryTypesServerModelMapper postHistoryTypesModelMapper
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
    <Hash>b5c91064011a8a83ce3d8f04e6cae0de</Hash>
</Codenesium>*/