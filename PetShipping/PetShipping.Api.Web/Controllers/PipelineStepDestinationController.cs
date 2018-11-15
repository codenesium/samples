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
	[Route("api/pipelineStepDestinations")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class PipelineStepDestinationController : AbstractPipelineStepDestinationController
	{
		public PipelineStepDestinationController(
			ApiSettings settings,
			ILogger<PipelineStepDestinationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineStepDestinationService pipelineStepDestinationService,
			IApiPipelineStepDestinationServerModelMapper pipelineStepDestinationModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineStepDestinationService,
			       pipelineStepDestinationModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d231d05db2cf3ff59599a753d17df33f</Hash>
</Codenesium>*/