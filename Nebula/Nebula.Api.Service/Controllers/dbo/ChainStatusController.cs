using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	[Route("api/chainStatus")]
	public class ChainStatusController: AbstractChainStatusController
	{
		public ChainStatusController(
			ILogger<ChainStatusController> logger,
			ITransactionCoordinator transactionCoordinator,
			IChainStatusRepository chainStatusRepository,
			IChainStatusModelValidator chainStatusModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       chainStatusRepository,
			       chainStatusModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>546987838844860252625000c053dd22</Hash>
</Codenesium>*/