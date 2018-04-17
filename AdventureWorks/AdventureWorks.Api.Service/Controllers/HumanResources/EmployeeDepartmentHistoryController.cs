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
	[Route("api/employeeDepartmentHistories")]
	[ApiVersion("1.0")]
	public class EmployeeDepartmentHistoryController: AbstractEmployeeDepartmentHistoryController
	{
		public EmployeeDepartmentHistoryController(
			ILogger<EmployeeDepartmentHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOEmployeeDepartmentHistory employeeDepartmentHistoryManager
			)
			: base(logger,
			       transactionCoordinator,
			       employeeDepartmentHistoryManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d5630168c9b354a0a913286391a7ae89</Hash>
</Codenesium>*/