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
	[ServiceFilter(typeof(ClaspFilter))]
	public class ClaspController: AbstractClaspController
	{
		public ClaspController(
			ILogger<ClaspController> logger,
			ITransactionCoordinator transactionCoordinator,
			IClaspRepository claspRepository
			)
			: base(logger,
			       transactionCoordinator,
			       claspRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>67da185a2963ded785a28f0d258d1f41</Hash>
</Codenesium>*/