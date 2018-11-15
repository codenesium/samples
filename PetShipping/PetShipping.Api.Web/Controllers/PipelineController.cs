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
	[Route("api/pipelines")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class PipelineController : AbstractPipelineController
	{
		public PipelineController(
			ApiSettings settings,
			ILogger<PipelineController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineService pipelineService,
			IApiPipelineServerModelMapper pipelineModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineService,
			       pipelineModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c356c915feaa48fc441dbadf3a3df8c2</Hash>
</Codenesium>*/