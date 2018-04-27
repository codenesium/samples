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
using PetShippingNS.Api.BusinessObjects;

namespace PetShippingNS.Api.Service
{
	[Route("api/handlerPipelineSteps")]
	[ApiVersion("1.0")]
	[Response]
	public class HandlerPipelineStepController: AbstractHandlerPipelineStepController
	{
		public HandlerPipelineStepController(
			ServiceSettings settings,
			ILogger<HandlerPipelineStepController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOHandlerPipelineStep handlerPipelineStepManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       handlerPipelineStepManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3c3109fd9f578216b1880f04b242c45d</Hash>
</Codenesium>*/