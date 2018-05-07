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
	[Route("api/pipelineStatus")]
	[ApiVersion("1.0")]
	public class PipelineStatusController: AbstractPipelineStatusController
	{
		public PipelineStatusController(
			ServiceSettings settings,
			ILogger<PipelineStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPipelineStatus pipelineStatusManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       pipelineStatusManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a731658085778c9e3d66d9a195b973d4</Hash>
</Codenesium>*/