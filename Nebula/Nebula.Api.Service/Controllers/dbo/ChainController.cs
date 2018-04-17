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
	[ServiceFilter(typeof(ChainFilter))]
	public class ChainController: AbstractChainController
	{
		public ChainController(
			ILogger<ChainController> logger,
			ITransactionCoordinator transactionCoordinator,
			IChainRepository chainRepository
			)
			: base(logger,
			       transactionCoordinator,
			       chainRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>56de1f8934ea6f9d5aecda678998b8e3</Hash>
</Codenesium>*/