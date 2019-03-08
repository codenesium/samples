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

	public class PostTypesController : AbstractPostTypesController
	{
		public PostTypesController(
			ApiSettings settings,
			ILogger<PostTypesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPostTypesService postTypesService,
			IApiPostTypesServerModelMapper postTypesModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       postTypesService,
			       postTypesModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b35b192be28a47cdf9af62164249a391</Hash>
</Codenesium>*/