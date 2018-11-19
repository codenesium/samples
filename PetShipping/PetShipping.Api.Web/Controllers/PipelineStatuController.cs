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

	public class PipelineStatuController : AbstractPipelineStatuController
	{
		public PipelineStatuController(
			ApiSettings settings,
			ILogger<PipelineStatuController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineStatuService pipelineStatuService,
			IApiPipelineStatuServerModelMapper pipelineStatuModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineStatuService,
			       pipelineStatuModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>35bf0f5ee18f49318c1f8755d2319555</Hash>
</Codenesium>*/