using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
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
    <Hash>ce6c080770484e2aa48e0cfd1056049f</Hash>
</Codenesium>*/