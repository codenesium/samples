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
			IEmployeeModelValidator employeeModelValidator)
			: base(logger, employeeRepository, employeeModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>129b5c7db72d60bd75698cc14ac0806b</Hash>
</Codenesium>*/