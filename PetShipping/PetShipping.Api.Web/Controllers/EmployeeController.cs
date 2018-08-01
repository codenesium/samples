using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShippingNS.Api.Web
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
			IApiEmployeeModelMapper employeeModelMapper
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
    <Hash>d803fcada12558fcfd95ea87587e4928</Hash>
</Codenesium>*/