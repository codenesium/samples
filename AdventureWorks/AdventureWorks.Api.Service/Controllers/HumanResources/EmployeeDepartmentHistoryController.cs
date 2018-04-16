using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/employeeDepartmentHistories")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(EmployeeDepartmentHistoryFilter))]
	public class EmployeeDepartmentHistoryController: AbstractEmployeeDepartmentHistoryController
	{
		public EmployeeDepartmentHistoryController(
			ILogger<EmployeeDepartmentHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository
			)
			: base(logger,
			       transactionCoordinator,
			       employeeDepartmentHistoryRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ff60deac6dec5ad3fec1e202be4ec687</Hash>
</Codenesium>*/