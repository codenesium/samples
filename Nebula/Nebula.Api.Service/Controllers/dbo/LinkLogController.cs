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
	[Route("api/linkLogs")]
	public class LinkLogsController: AbstractLinkLogsController
	{
		public LinkLogsController(
			ILogger<LinkLogsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ILinkLogRepository linkLogRepository,
			ILinkLogModelValidator linkLogModelValidator
			) : base(logger,
			         transactionCoordinator,
			         linkLogRepository,
			         linkLogModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d03318404a9ecc06128f66e52cfcfde5</Hash>
</Codenesium>*/