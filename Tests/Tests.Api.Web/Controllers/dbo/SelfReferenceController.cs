using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    <Hash>61b1b4590217253c5d14074380096660</Hash>
</Codenesium>*/