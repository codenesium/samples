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
	[Route("api/pipelines")]
	[ApiVersion("1.0")]
	public class PipelineController: AbstractPipelineController
	{
		public PipelineController(
			ServiceSettings settings,
			ILogger<PipelineController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineService pipelineService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1879891a7e3962a5b0b20e38c81f255c</Hash>
</Codenesium>*/