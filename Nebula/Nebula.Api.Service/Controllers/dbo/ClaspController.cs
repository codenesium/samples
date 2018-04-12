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
	[Route("api/clasps")]
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
    <Hash>a96c4d951815e0bbc41e00bdfae3cdd1</Hash>
</Codenesium>*/