using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class EmployeeService : AbstractEmployeeService, IEmployeeService
	{
		public EmployeeService(
			ILogger<IEmployeeRepository> logger,
			IEmployeeRepository employeeRepository,
			IApiEmployeeServerRequestModelValidator employeeModelValidator,
			IBOLEmployeeMapper bolEmployeeMapper,
			IDALEmployeeMapper dalEmployeeMapper,
			IBOLJobCandidateMapper bolJobCandidateMapper,
			IDALJobCandidateMapper dalJobCandidateMapper)
			: base(logger,
			       employeeRepository,
			       employeeModelValidator,
			       bolEmployeeMapper,
			       dalEmployeeMapper,
			       bolJobCandidateMapper,
			       dalJobCandidateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>cd15ab6b4d870228dd7b54d79c13a014</Hash>
</Codenesium>*/