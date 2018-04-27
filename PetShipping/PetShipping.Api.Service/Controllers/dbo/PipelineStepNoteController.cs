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
	[Response]
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
    <Hash>f77b4000da016df218c44a9d3fb655a8</Hash>
</Codenesium>*/