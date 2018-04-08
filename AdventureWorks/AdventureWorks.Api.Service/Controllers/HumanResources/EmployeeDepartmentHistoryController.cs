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
	public class EmployeeDepartmentHistoriesController: AbstractEmployeeDepartmentHistoriesController
	{
		public EmployeeDepartmentHistoriesController(
			ILogger<EmployeeDepartmentHistoriesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository,
			IEmployeeDepartmentHistoryModelValidator employeeDepartmentHistoryModelValidator
			) : base(logger,
			         transactionCoordinator,
			         employeeDepartmentHistoryRepository,
			         employeeDepartmentHistoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7f4bfab2964e9896e0f605d56533b1c8</Hash>
</Codenesium>*/