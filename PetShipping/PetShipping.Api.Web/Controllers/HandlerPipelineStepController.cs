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
	[Route("api/handlerPipelineSteps")]
	[ApiController]
	[ApiVersion("1.0")]
	public class HandlerPipelineStepController : AbstractHandlerPipelineStepController
	{
		public HandlerPipelineStepController(
			ApiSettings settings,
			ILogger<HandlerPipelineStepController> logger,
			ITransactionCoordinator transactionCoordinator,
			IHandlerPipelineStepService handlerPipelineStepService,
			IApiHandlerPipelineStepModelMapper handlerPipelineStepModelMapper
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
    <Hash>89d48f114d08fa10d9ea1aabd4e1426e</Hash>
</Codenesium>*/