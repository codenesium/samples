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
			ApplicationContext context,
			IErrorLogRepository errorLogRepository,
			IErrorLogModelValidator errorLogModelValidator
			) : base(logger,
			         context,
			         errorLogRepository,
			         errorLogModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5413386b81ab09a9bdd0501e1878ff01</Hash>
</Codenesium>*/