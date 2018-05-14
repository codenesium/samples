using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
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
    <Hash>a251c449ef4a0f432eea37bf775d9d5f</Hash>
</Codenesium>*/