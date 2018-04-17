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
	[Route("api/clasps")]
	[ApiVersion("1.0")]
	public class ClaspController: AbstractClaspController
	{
		public ClaspController(
			ILogger<ClaspController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOClasp claspManager
			)
			: base(logger,
			       transactionCoordinator,
			       claspManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e730884748099d4efec0ab8f16513cb9</Hash>
</Codenesium>*/