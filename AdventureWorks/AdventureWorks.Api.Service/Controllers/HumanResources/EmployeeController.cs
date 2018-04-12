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
	public class EmployeeController: AbstractEmployeeController
	{
		public EmployeeController(
			ILogger<EmployeeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeeRepository employeeRepository,
			IEmployeeModelValidator employeeModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       employeeRepository,
			       employeeModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c3d75a5585bf7b4b0ff7ea1a4e05fa33</Hash>
</Codenesium>*/