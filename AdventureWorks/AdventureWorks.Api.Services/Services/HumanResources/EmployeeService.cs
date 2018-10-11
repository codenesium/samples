using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class EmployeeService : AbstractEmployeeService, IEmployeeService
	{
		public EmployeeService(
			ILogger<IEmployeeRepository> logger,
			IEmployeeRepository employeeRepository,
			IApiEmployeeRequestModelValidator employeeModelValidator,
			IBOLEmployeeMapper bolemployeeMapper,
			IDALEmployeeMapper dalemployeeMapper,
			IBOLEmployeeDepartmentHistoryMapper bolEmployeeDepartmentHistoryMapper,
			IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper,
			IBOLEmployeePayHistoryMapper bolEmployeePayHistoryMapper,
			IDALEmployeePayHistoryMapper dalEmployeePayHistoryMapper,
			IBOLJobCandidateMapper bolJobCandidateMapper,
			IDALJobCandidateMapper dalJobCandidateMapper)
			: base(logger,
			       employeeRepository,
			       employeeModelValidator,
			       bolemployeeMapper,
			       dalemployeeMapper,
			       bolEmployeeDepartmentHistoryMapper,
			       dalEmployeeDepartmentHistoryMapper,
			       bolEmployeePayHistoryMapper,
			       dalEmployeePayHistoryMapper,
			       bolJobCandidateMapper,
			       dalJobCandidateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2514a38029f184b29a311d5a25553455</Hash>
</Codenesium>*/