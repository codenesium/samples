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
	[Route("api/handlerPipelineSteps")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class HandlerPipelineStepController : AbstractHandlerPipelineStepController
	{
		public HandlerPipelineStepController(
			ApiSettings settings,
			ILogger<HandlerPipelineStepController> logger,
			ITransactionCoordinator transactionCoordinator,
			IHandlerPipelineStepService handlerPipelineStepService,
			IApiHandlerPipelineStepServerModelMapper handlerPipelineStepModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       handlerPipelineStepService,
			       handlerPipelineStepModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>36da68925af379dec96a416c299552b4</Hash>
</Codenesium>*/