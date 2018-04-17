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
	[Route("api/employees")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class EmployeeController: AbstractEmployeeController
	{
		public EmployeeController(
			ILogger<EmployeeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOEmployee employeeManager
			)
			: base(logger,
			       transactionCoordinator,
			       employeeManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f901aefaeac4dd9990b20a0a41589135</Hash>
</Codenesium>*/