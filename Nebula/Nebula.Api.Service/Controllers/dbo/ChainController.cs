using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.BusinessObjects;

namespace NebulaNS.Api.Service
{
	[Route("api/chains")]
	[ApiVersion("1.0")]
	[Response]
	public class ChainController: AbstractChainController
	{
		public ChainController(
			ServiceSettings settings,
			ILogger<ChainController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOChain chainManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       chainManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>bf60c259d93f845f2c1a3feccda8f564</Hash>
</Codenesium>*/