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
	[Route("api/tags")]
	[ApiController]
	[ApiVersion("1.0")]
	public class TagsController : AbstractTagsController
	{
		public TagsController(
			ApiSettings settings,
			ILogger<TagsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITagsService tagsService,
			IApiTagsModelMapper tagsModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       tagsService,
			       tagsModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>29551bd3edaea479dca096586b53507f</Hash>
</Codenesium>*/