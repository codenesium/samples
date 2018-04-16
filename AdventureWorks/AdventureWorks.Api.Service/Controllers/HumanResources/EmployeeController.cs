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
	[ServiceFilter(typeof(EmployeeFilter))]
	public class EmployeeController: AbstractEmployeeController
	{
		public EmployeeController(
			ILogger<EmployeeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeeRepository employeeRepository
			)
			: base(logger,
			       transactionCoordinator,
			       employeeRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>01e129a1c96c0783765e10058d27de20</Hash>
</Codenesium>*/