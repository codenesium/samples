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
	[Route("api/pipelineStatus")]
	[ApiController]
	[ApiVersion("1.0")]

	public class PipelineStatusController : AbstractPipelineStatusController
	{
		public PipelineStatusController(
			ApiSettings settings,
			ILogger<PipelineStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineStatusService pipelineStatusService,
			IApiPipelineStatusServerModelMapper pipelineStatusModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineStatusService,
			       pipelineStatusModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5c4791e0f9115575dda7e41755519605</Hash>
</Codenesium>*/