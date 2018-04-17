using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.BusinessObjects;

namespace NebulaNS.Api.Service
{
	[Route("api/chainStatus")]
	[ApiVersion("1.0")]
	public class ChainStatusController: AbstractChainStatusController
	{
		public ChainStatusController(
			ILogger<ChainStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOChainStatus chainStatusManager
			)
			: base(logger,
			       transactionCoordinator,
			       chainStatusManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ba42c1c2022ef2adae3b72ea030875cc</Hash>
</Codenesium>*/