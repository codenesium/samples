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
			IEmployeeModelValidator employeeModelValidator)
			: base(logger, employeeRepository, employeeModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>67b54bef3867802058c1214adb8ae94a</Hash>
</Codenesium>*/