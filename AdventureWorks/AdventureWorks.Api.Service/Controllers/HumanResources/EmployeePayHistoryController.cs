using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/employeePayHistories")]
	[ApiVersion("1.0")]
	public class EmployeePayHistoryController: AbstractEmployeePayHistoryController
	{
		public EmployeePayHistoryController(
			ServiceSettings settings,
			ILogger<EmployeePayHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOEmployeePayHistory employeePayHistoryManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       employeePayHistoryManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4ee54951bade2292e4e0e732b58f6a5c</Hash>
</Codenesium>*/