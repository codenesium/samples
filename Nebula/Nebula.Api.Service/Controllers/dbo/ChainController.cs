using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	[Route("api/chains")]
	[ApiVersion("1.0")]
	public class ChainController: AbstractChainController
	{
		public ChainController(
			ILogger<ChainController> logger,
			ITransactionCoordinator transactionCoordinator,
			IChainRepository chainRepository,
			IChainModelValidator chainModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       chainRepository,
			       chainModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1102cb5458d8125dbb727c30b9533626</Hash>
</Codenesium>*/