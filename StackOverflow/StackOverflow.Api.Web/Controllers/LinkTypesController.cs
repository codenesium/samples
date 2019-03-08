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
	[Route("api/linkTypes")]
	[ApiController]
	[ApiVersion("1.0")]

	public class LinkTypesController : AbstractLinkTypesController
	{
		public LinkTypesController(
			ApiSettings settings,
			ILogger<LinkTypesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkTypesService linkTypesService,
			IApiLinkTypesServerModelMapper linkTypesModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       linkTypesService,
			       linkTypesModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c70fa5891b03f20381cb0e9aae799a4f</Hash>
</Codenesium>*/