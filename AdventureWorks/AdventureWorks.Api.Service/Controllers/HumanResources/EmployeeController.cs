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
			ApplicationContext context,
			IEmployeeRepository employeeRepository,
			IEmployeeModelValidator employeeModelValidator
			) : base(logger,
			         context,
			         employeeRepository,
			         employeeModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>99dc0788fbc91bfb7898e80cbbcbab7c</Hash>
</Codenesium>*/