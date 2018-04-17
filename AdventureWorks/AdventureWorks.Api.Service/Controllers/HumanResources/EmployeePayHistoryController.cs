using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/employeePayHistories")]
	[ApiVersion("1.0")]
	public class EmployeePayHistoryController: AbstractEmployeePayHistoryController
	{
		public EmployeePayHistoryController(
			ILogger<EmployeePayHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOEmployeePayHistory employeePayHistoryManager
			)
			: base(logger,
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
    <Hash>ba372103c1ec3eebe687bf939e8b2e50</Hash>
</Codenesium>*/