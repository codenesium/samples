using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
	[Route("api/pipelineStepStatus")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class PipelineStepStatuController : AbstractPipelineStepStatuController
	{
		public PipelineStepStatuController(
			ApiSettings settings,
			ILogger<PipelineStepStatuController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineStepStatuService pipelineStepStatuService,
			IApiPipelineStepStatuServerModelMapper pipelineStepStatuModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineStepStatuService,
			       pipelineStepStatuModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3d851687d5c3fcdb5be39d627ce4029b</Hash>
</Codenesium>*/