using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class EmployeeService: AbstractEmployeeService, IEmployeeService
	{
		public EmployeeService(
			ILogger<EmployeeRepository> logger,
			IEmployeeRepository employeeRepository,
			IApiEmployeeRequestModelValidator employeeModelValidator,
			IBOLEmployeeMapper BOLemployeeMapper,
			IDALEmployeeMapper DALemployeeMapper)
			: base(logger, employeeRepository,
			       employeeModelValidator,
			       BOLemployeeMapper,
			       DALemployeeMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>5a6f51180a24a616760b8cbd57f218f4</Hash>
</Codenesium>*/