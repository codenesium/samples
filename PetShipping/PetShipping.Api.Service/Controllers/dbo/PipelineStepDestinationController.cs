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
	[Route("api/pipelineStepDestinations")]
	[ApiVersion("1.0")]
	[Response]
	public class PipelineStepDestinationController: AbstractPipelineStepDestinationController
	{
		public PipelineStepDestinationController(
			ServiceSettings settings,
			ILogger<PipelineStepDestinationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPipelineStepDestination pipelineStepDestinationManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineStepDestinationManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4c71d7214f1d572c747f0ee9d33909c9</Hash>
</Codenesium>*/