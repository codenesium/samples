using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
	public class PipelineStepNoteController : AbstractPipelineStepNoteController
	{
		public PipelineStepNoteController(
			ApiSettings settings,
			ILogger<PipelineStepNoteController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPipelineStepNoteService pipelineStepNoteService,
			IApiPipelineStepNoteModelMapper pipelineStepNoteModelMapper
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
    <Hash>ff19e478b6ffdc126a6c171d5e6730e0</Hash>
</Codenesium>*/