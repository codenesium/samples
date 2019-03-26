using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/employees")]
	[ApiController]
	[ApiVersion("1.0")]

	public class EmployeeController : AbstractEmployeeController
	{
		public EmployeeController(
			ApiSettings settings,
			ILogger<EmployeeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IEmployeeService employeeService,
			IApiEmployeeServerModelMapper employeeModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       employeeService,
			       employeeModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7edaec7d34cc1a5f5cb2a5192781387f</Hash>
</Codenesium>*/