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
	[Route("api/employees")]
	public class EmployeesController: AbstractEmployeesController
	{
		public EmployeesController(
			ILogger<EmployeesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeeRepository employeeRepository,
			IEmployeeModelValidator employeeModelValidator
			) : base(logger,
			         transactionCoordinator,
			         employeeRepository,
			         employeeModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9c1fd76cbfbab463ea2f934998ec5090</Hash>
</Codenesium>*/