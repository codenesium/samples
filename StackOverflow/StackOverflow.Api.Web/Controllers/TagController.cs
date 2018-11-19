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
	[Route("api/tags")]
	[ApiController]
	[ApiVersion("1.0")]

	public class TagController : AbstractTagController
	{
		public TagController(
			ApiSettings settings,
			ILogger<TagController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITagService tagService,
			IApiTagServerModelMapper tagModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       tagService,
			       tagModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c808a0350c9b33ff28ad33d1e748a244</Hash>
</Codenesium>*/