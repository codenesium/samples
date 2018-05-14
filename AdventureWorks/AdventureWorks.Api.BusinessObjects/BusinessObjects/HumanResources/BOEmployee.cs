using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOEmployee: AbstractBOEmployee, IBOEmployee
	{
		public BOEmployee(
			ILogger<EmployeeRepository> logger,
			IEmployeeRepository employeeRepository,
			IApiEmployeeModelValidator employeeModelValidator)
			: base(logger, employeeRepository, employeeModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>459b542f1d5c79c85355ea76e20c641d</Hash>
</Codenesium>*/