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
	[Route("api/clasps")]
	[ApiVersion("1.0")]
	public class ClaspController: AbstractClaspController
	{
		public ClaspController(
			ILogger<ClaspController> logger,
			ITransactionCoordinator transactionCoordinator,
			IClaspRepository claspRepository,
			IClaspModelValidator claspModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       claspRepository,
			       claspModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>59e4431a96060f7f0ab81eb70b9dbed5</Hash>
</Codenesium>*/