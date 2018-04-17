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
	[ResponseFilter]
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
    <Hash>d6dd2681a769995752b30d71d0e20b0c</Hash>
</Codenesium>*/