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
			IApiEmployeeRequestModelValidator employeeModelValidator,
			IBOLEmployeeMapper employeeMapper)
			: base(logger, employeeRepository, employeeModelValidator, employeeMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>ed80cb50d6d6fc3313ec6522f7096cff</Hash>
</Codenesium>*/