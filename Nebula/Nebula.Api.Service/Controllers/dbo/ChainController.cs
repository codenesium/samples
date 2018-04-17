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
	[Route("api/chains")]
	[ApiVersion("1.0")]
	public class ChainController: AbstractChainController
	{
		public ChainController(
			ILogger<ChainController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOChain chainManager
			)
			: base(logger,
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
    <Hash>0d3e76c6a3a2886de730d68cbb6517d1</Hash>
</Codenesium>*/