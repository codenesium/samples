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
    <Hash>e75b53e7aca091cfe5f17666f51e7ba2</Hash>
</Codenesium>*/