using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	[Route("api/errorLogs")]
	public class ErrorLogsController: AbstractErrorLogsController
	{
		public ErrorLogsController(
			ILogger<ErrorLogsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IErrorLogRepository errorLogRepository,
			IErrorLogModelValidator errorLogModelValidator
			) : base(logger,
			         transactionCoordinator,
			         errorLogRepository,
			         errorLogModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>825b3f9996abfa599a8001ff16088cdd</Hash>
</Codenesium>*/