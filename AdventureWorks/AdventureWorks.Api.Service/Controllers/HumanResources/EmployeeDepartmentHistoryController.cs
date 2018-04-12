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
	[Route("api/employeeDepartmentHistories")]
	public class EmployeeDepartmentHistoryController: AbstractEmployeeDepartmentHistoryController
	{
		public EmployeeDepartmentHistoryController(
			ILogger<EmployeeDepartmentHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository,
			IEmployeeDepartmentHistoryModelValidator employeeDepartmentHistoryModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       employeeDepartmentHistoryRepository,
			       employeeDepartmentHistoryModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d30ca2b7bfe2a83f26360ed899a2d434</Hash>
</Codenesium>*/