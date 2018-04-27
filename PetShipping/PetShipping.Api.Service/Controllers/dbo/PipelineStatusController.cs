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
	[Response]
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
    <Hash>048676af35b41a2a544af1d62726b4ff</Hash>
</Codenesium>*/