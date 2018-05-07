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
    <Hash>a28f3b97ba2d92827f67868d514fee0a</Hash>
</Codenesium>*/