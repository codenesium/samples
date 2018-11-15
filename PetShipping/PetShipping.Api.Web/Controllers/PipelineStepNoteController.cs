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
	[Route("api/pipelineStepNotes")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class PipelineStepNoteController : AbstractPipelineStepNoteController
	{
		public PipelineStepNoteController(
			ApiSettings settings,
			ILogger<PipelineStepNoteController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineStepNoteService pipelineStepNoteService,
			IApiPipelineStepNoteServerModelMapper pipelineStepNoteModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineStepNoteService,
			       pipelineStepNoteModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>89331ea900a8e5abbaf7f98c65bc009b</Hash>
</Codenesium>*/