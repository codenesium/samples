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
	[Route("api/pipelines")]
	[ApiVersion("1.0")]
	public class PipelineController: AbstractPipelineController
	{
		public PipelineController(
			ServiceSettings settings,
			ILogger<PipelineController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPipeline pipelineManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f110b46c798d86bda0a1e5c1fa61f779</Hash>
</Codenesium>*/