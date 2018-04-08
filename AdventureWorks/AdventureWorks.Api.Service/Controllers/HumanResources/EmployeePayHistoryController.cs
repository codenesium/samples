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
	[Route("api/employeePayHistories")]
	public class EmployeePayHistoriesController: AbstractEmployeePayHistoriesController
	{
		public EmployeePayHistoriesController(
			ILogger<EmployeePayHistoriesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeePayHistoryRepository employeePayHistoryRepository,
			IEmployeePayHistoryModelValidator employeePayHistoryModelValidator
			) : base(logger,
			         transactionCoordinator,
			         employeePayHistoryRepository,
			         employeePayHistoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b2b16fe130ef89d85bfdb26a83008afd</Hash>
</Codenesium>*/