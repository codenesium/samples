using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Web
{
	[Route("api/handlerPipelineSteps")]
	[ApiVersion("1.0")]
	public class HandlerPipelineStepController: AbstractHandlerPipelineStepController
	{
		public HandlerPipelineStepController(
			ServiceSettings settings,
			ILogger<HandlerPipelineStepController> logger,
			ITransactionCoordinator transactionCoordinator,
			IHandlerPipelineStepService handlerPipelineStepService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       handlerPipelineStepService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>610633b46e569c7de626c69e45fea214</Hash>
</Codenesium>*/