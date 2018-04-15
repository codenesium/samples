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
	[Route("api/employees")]
	[ApiVersion("1.0")]
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
    <Hash>c87bc1a889c582597f1c1a1cc7a3c358</Hash>
</Codenesium>*/