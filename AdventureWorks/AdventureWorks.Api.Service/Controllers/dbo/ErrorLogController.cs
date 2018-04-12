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
	public class ErrorLogController: AbstractErrorLogController
	{
		public ErrorLogController(
			ILogger<ErrorLogController> logger,
			ITransactionCoordinator transactionCoordinator,
			IErrorLogRepository errorLogRepository,
			IErrorLogModelValidator errorLogModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       errorLogRepository,
			       errorLogModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>adb31efe6fe286c478fc651ea274d64d</Hash>
</Codenesium>*/