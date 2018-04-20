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
	[Route("api/chainStatus")]
	[ApiVersion("1.0")]
	[Response]
	public class ChainStatusController: AbstractChainStatusController
	{
		public ChainStatusController(
			ServiceSettings settings,
			ILogger<ChainStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOChainStatus chainStatusManager
			)
			: base(settings,
			       logger,
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
    <Hash>1146b0397d483f3b7fc83103467749e9</Hash>
</Codenesium>*/