using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShippingNS.Api.Web
{
	[Route("api/pipelines")]
	[ApiController]
	[ApiVersion("1.0")]
	public class PipelineController : AbstractPipelineController
	{
		public PipelineController(
			ApiSettings settings,
			ILogger<PipelineController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineService pipelineService,
			IApiPipelineModelMapper pipelineModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineService,
			       pipelineModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a5813962048db8934664d1c8603dd218</Hash>
</Codenesium>*/