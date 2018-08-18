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
using System.Threading.Tasks;

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
    <Hash>3750ea82ee3f6356e466e4fa185d4d3d</Hash>
</Codenesium>*/