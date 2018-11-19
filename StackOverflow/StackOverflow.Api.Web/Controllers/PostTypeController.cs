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
	[Route("api/postTypes")]
	[ApiController]
	[ApiVersion("1.0")]

	public class PostTypeController : AbstractPostTypeController
	{
		public PostTypeController(
			ApiSettings settings,
			ILogger<PostTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPostTypeService postTypeService,
			IApiPostTypeServerModelMapper postTypeModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       postTypeService,
			       postTypeModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b6bca0efd581cb59cd28f424aeab4d46</Hash>
</Codenesium>*/