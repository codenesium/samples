using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;

namespace TestsNS.Api.Web
{
	[Route("api/selfReferences")]
	[ApiController]
	[ApiVersion("1.0")]
	public class SelfReferenceController : AbstractSelfReferenceController
	{
		public SelfReferenceController(
			ApiSettings settings,
			ILogger<SelfReferenceController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISelfReferenceService selfReferenceService,
			IApiSelfReferenceModelMapper selfReferenceModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       selfReferenceService,
			       selfReferenceModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8f0ea282afd851b3b191b4a70fcc5cb7</Hash>
</Codenesium>*/