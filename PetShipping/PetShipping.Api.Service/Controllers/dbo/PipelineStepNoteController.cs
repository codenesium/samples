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
	[Route("api/pipelineStepNotes")]
	[ApiVersion("1.0")]
	public class PipelineStepNoteController: AbstractPipelineStepNoteController
	{
		public PipelineStepNoteController(
			ServiceSettings settings,
			ILogger<PipelineStepNoteController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPipelineStepNote pipelineStepNoteManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineStepNoteManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2a8ffbaf8c11e88e79b84d5f4f623c55</Hash>
</Codenesium>*/