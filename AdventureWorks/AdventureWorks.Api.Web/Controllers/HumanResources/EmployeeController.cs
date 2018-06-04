using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/employees")]
	[ApiVersion("1.0")]
	public class EmployeeController: AbstractEmployeeController
	{
		public EmployeeController(
			ServiceSettings settings,
			ILogger<EmployeeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeeService employeeService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       employeeService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d282f79a772637e3928c3d02c1a49dfb</Hash>
</Codenesium>*/