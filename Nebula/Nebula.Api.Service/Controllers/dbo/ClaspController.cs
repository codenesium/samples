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
	[Route("api/clasps")]
	[ApiVersion("1.0")]
	[Response]
	public class ClaspController: AbstractClaspController
	{
		public ClaspController(
			ServiceSettings settings,
			ILogger<ClaspController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOClasp claspManager
			)
			: base(settings,
			       logger,
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
    <Hash>cd6acfbd1b8ce3ee238bd685002c876d</Hash>
</Codenesium>*/